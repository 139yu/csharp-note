using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ImTools;
using Microsoft.Extensions.Logging;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using SmartParking.Client.Commons.Config;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.Commons.Helper;
using SmartParking.Client.Commons.Models;
using SmartParking.Client.IBLL;
using SmartParking.Client.Start.Events;

namespace SmartParking.Client.Start.ViewModels
{
    public class LoginWindowViewModel : BindableBase
    {
        // 登录前检查版本是否要更新，服务端有文件，记录文件信息（文件名称、大小、md5）
        // 客户端拿到文件信息进行比对
        // 如果需要更新，将服务器文件下载到本地进行覆盖
        public LoginWindowViewModel(IUserBll userBll, IUserTokenProvider userTokenProvider, IFileBll fileBll,
            ILogger<LoginWindowViewModel> logger,IEventAggregator ea)
        {
            _logger = logger;
            _userBll = userBll;
            _userTokenProvider = userTokenProvider;
            Console.WriteLine(_userTokenProvider.GetHashCode());
            _ea = ea;
            LoginCommand = new DelegateCommand<object>(ExecuteLogin);
            _fileBll = fileBll;
            UpdateVersion();
        }

        public Dispatcher MainDispatcher = Application.Current.Dispatcher;
        #region 页面属性

        private string _loadingMessage;
        private ILogger _logger;

        public string LoadingMessage
        {
            get { return _loadingMessage; }
            set { SetProperty(ref _loadingMessage, value); }
        }

        private bool _canOperation = true;

        public bool CanOperation
        {
            get { return _canOperation; }
            set { SetProperty(ref _canOperation, value); }
        }


        private bool _loadingVisibility = false;

        public bool LoadingVisibility
        {
            get { return _loadingVisibility; }
            set { SetProperty(ref _loadingVisibility, value); }
        }


        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        #endregion

        private IUserTokenProvider _userTokenProvider;
        private IUserBll _userBll;

        private IFileBll _fileBll;
        private IEventAggregator _ea;

        #region 版本检查

        private void UpdateVersion()
        {
            LoadingMessage = "版本检查中......";
            LoadingTrigger();
            Task.Run(async () =>
            {
                try
                {
                    var localFiles = await _fileBll.GetLocalFiles();
                    if (localFiles != null)
                    {
                        var files =
                            (from d in localFiles.AsEnumerable()
                                select new UpgradeFileModel()
                                {
                                    FileId = int.Parse(d["file_id"].ToString()),
                                    FileName = d["file_name"].ToString(),
                                    FileMd5 = d["file_md5"].ToString(),
                                    FileLen = long.Parse(d["file_len"].ToString()),
                                }).ToList();

                        var serverRes = await _fileBll.GetServerFiles();
                        if (serverRes != null && serverRes.Code == 200)
                        {
                            var upgradeFiles = new List<UpgradeFileModel>();
                            var serverFiles = serverRes.Data;
                            foreach (var file in serverFiles)
                            {
                                // 本地文件中没有，或者本地文件中有，但是md5不同
                                var exists = (!files.Exists(f => file.FileName == f.FileName) ||
                                              files.Exists(
                                                  f => file.FileName == f.FileName && file.FileMd5 != f.FileMd5));
                                if (exists)
                                {
                                    upgradeFiles.Add(file);
                                }
                            }

                            if (upgradeFiles.Count > 0)
                            {
                                var fileJson = JSONUtils.ToJsonString(upgradeFiles);
                                var tempFile = Path.GetTempFileName();
                                File.WriteAllText(tempFile, fileJson);
                                Process.Start(new ProcessStartInfo()
                                {
                                    FileName = "SmartParking.Client.UpgradeApp.exe",
                                    Arguments = $"--mainifest \"{tempFile}\"",
                                    UseShellExecute = true
                                });
                                _ea.GetEvent<WindowCloseEvent>().Publish();
                            }
                        }
                        else
                        {
                            throw new Exception("请求失败");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
                finally
                {
                    LoadingTrigger();
                }
            });
        }

        #endregion

        #region Login

        public UserLoginModel LoginModel { get; set; } = new UserLoginModel();
        public DelegateCommand<object> LoginCommand { get; }
        

        private void ExecuteLogin(object sender)
        {
            LoadingMessage = "正在登录......";
            var username = LoginModel.Username;
            var password = LoginModel.Password;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ErrorMessage = "请输入账号或密码！";
                return;
            }

            LoadingTrigger();

            Task.Run(async () =>
            {
                try
                {
                    var result = await _userBll.Login(LoginModel);
                    if (result == null || result.Code != 200)
                    {
                        MainDispatcher.Invoke(() =>
                        {
                            ErrorMessage = result == null ? "登录失败" : result.Msg;
                        });
                        return;
                    }

                    var loginResponse = result.Data;
                    MainDispatcher.Invoke(() =>
                    {
                        _userTokenProvider.CurrentUser = loginResponse.User;
                        var window = sender as Window;
                        window.DialogResult = true;
                    });
                    
                    _userTokenProvider.BearerToken = loginResponse.Token;
                }
                catch (Exception e)
                {
                    MainDispatcher.Invoke(() =>
                    {
                        ErrorMessage = e.Message;
                    });
                    
                }
                finally
                {
                    LoadingTrigger();
                }
            });
        }

        #endregion

        private void LoadingTrigger()
        {
            LoadingVisibility = !LoadingVisibility;
            CanOperation = !CanOperation;
        }
    }
}