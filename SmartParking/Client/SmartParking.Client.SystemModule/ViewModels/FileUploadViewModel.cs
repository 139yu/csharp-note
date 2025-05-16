using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DryIoc;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SmartParking.Client.Commons.Entity.Response;
using SmartParking.Client.IBLL;
using SmartParking.Client.SystemModule.Models;

namespace SmartParking.Client.SystemModule.ViewModels
{
    public class FileUploadViewModel : BaseNavigationViewModel
    {
  

        private IFileBll _fileBll;
        private IDialogService _dialogService;
        public FileUploadViewModel(IFileBll fileBll, IDialogService dialogService, IContainer container,IRegionManager regionManager): base(container,regionManager)
        {
            PageTitle = "文件上传";
            _dialogService = dialogService;
            _fileBll = fileBll;
            QueryData();
        }

        private bool _loadingVisibility = true;

        public bool LoadingVisibility
        {
            get => _loadingVisibility;
            set => SetProperty(ref _loadingVisibility, value);
        }

        private ObservableCollection<FileModel> _serverFiles;

        public ObservableCollection<FileModel> ServerFiles
        {
            get => _serverFiles;
            set => SetProperty(ref _serverFiles, value);
        }

        private string _keyword;

        public string Keyword
        {
            get => _keyword;
            set => SetProperty(ref _keyword, value);
        }

        private async void QueryData()
        {
            try
            {
                LoadingVisibility = true;
                await Task.Delay(100);
                Task.Run(async () =>
                {
                    var result = await _fileBll.GetServerFiles(Keyword);
                    if (result != null && result.Code == 200)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ServerFiles = new ObservableCollection<FileModel>((from f in result.Data
                                select new FileModel()
                                {
                                    FileId = f.FileId,
                                    FileName = f.FileName,
                                    OutputDir = f.OutputDir,
                                    UploadTime = f.UploadTime,
                                    DeleteCommand = new DelegateCommand(async () =>
                                    {
                                        var res = await _fileBll.DeleteFile(f.FileId);
                                        if (res != null && res.Code == 200)
                                        {
                                            Console.WriteLine("删除成功");
                                        }

                                        QueryData();
                                    })
                                }).ToList());
                        });
                    }
                });
            }
            finally
            {
                LoadingVisibility = false;
            }
        }

        #region 命令

        private ICommand _uploadFileCommand;
        private ICommand _refreshCommand;
        
        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new DelegateCommand(DoRefresh);
                }

                return _refreshCommand;
            }
        }

        public ICommand UploadFileCommand
        {
            get
            {
                if (_uploadFileCommand == null)
                {
                    _uploadFileCommand = new DelegateCommand(DoUploadFile);
                }

                return _uploadFileCommand;
            }
        }

        private void DoUploadFile()
        {
            _dialogService.ShowDialog("AddFileDialog");
        }

        private void DoRefresh()
        {
            QueryData();
        }

        #endregion

       
    }
}