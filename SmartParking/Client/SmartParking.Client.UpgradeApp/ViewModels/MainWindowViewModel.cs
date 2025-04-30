using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SmartParking.Client.UpgradeApp.Base;
using SmartParking.Client.UpgradeApp.BLL;
using SmartParking.Client.UpgradeApp.Events;
using SmartParking.Client.UpgradeApp.Helper;
using SmartParking.Client.UpgradeApp.Models;
using static System.Windows.Application;

namespace SmartParking.Client.UpgradeApp.ViewModels
{
    public class MainWindowViewModel: INotifyPropertyChanged, INotifyCollectionChanged
    {
        public event DownloadFileSuccessHandler DownloadFileSuccessHandler;
        public event DownloadAllSuccessHandler DownloadAllSuccessHandler;
        
        private ObservableCollection<UpgradeFileModel> upgradeFiles;
        public ObservableCollection<UpgradeFileModel> UpgradeFiles
        {
            get
            {
                return upgradeFiles;
            }
            set
            {
                if (upgradeFiles != value)
                {
                    upgradeFiles = value;
                    OnPropertyChanged(nameof(UpgradeFiles));
                }
            }
        }
        private double _downloadProgress = 0d;
        private LocalFileBll LocalFileBll = new LocalFileBll();
        public double DownloadProgress
        {
            get => _downloadProgress;
            set
            {
                if (_downloadProgress != value)
                {
                    _downloadProgress = value;
                    OnPropertyChanged(nameof(DownloadProgress));
                }
            }
        }
        private HttpService httpService;
        public ICommand DownloadCommand { get; set; }
        private int _fileCount = 0;
        
        public int FileCount
        {
            get => _fileCount;
            set
            {
                if (_fileCount != value)
                {
                    _fileCount = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private int _alreadyCount = 0;

        public int AlreadyCount
        {
            get => _alreadyCount;
            set
            {
                if (_alreadyCount != value)
                {
                    _alreadyCount = value;
                    OnPropertyChanged();
                }
            }
        }

        private long totalBytes = 1;
        public MainWindowViewModel(string tempfile)
        {
            DownloadCommand = new DelegateCommand(ExecuteDownLoadCommand);
            if (File.Exists(tempfile))
            {
                var json = File.ReadAllText(tempfile);
                var upgradeFileModels = JSONUtils.ToObject<List<UpgradeFileModel>>(json);
                if (upgradeFileModels.Count > 0)
                {
                    FileCount = upgradeFileModels.Count;
                    UpgradeFiles = new ObservableCollection<UpgradeFileModel>(upgradeFileModels);
                    totalBytes = UpgradeFiles.Sum(f => f.FileLen);
                    UpgradeFiles.CollectionChanged += UpgradeFilesOnCollectionChanged;
                    httpService = new HttpService();
                    DownloadFileSuccessHandler += HandlerFileDownloadSuccess;
                }
                // File.Delete(tempfile);
            }
            else
            {
                throw new Exception("File does not exist");
            }
            
        }

        private void ExecuteDownLoadCommand(object obj)
        {
            MessageBox.Show("开始更新");
            Task.Run( async () =>
            {
                try
                {
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    for (var i = 0; i < UpgradeFiles.Count; i++)
                    {
                        var file = UpgradeFiles[i];
                        string savePath = Path.Combine(baseDir, "Upgrade",UpgradeFiles[i].FileName);
                        string url = $"http://127.0.0.1:5000/api/upgradeFile/Download/{file.FileMd5}";
                        await DownloadSingleFileAsnyc(url, savePath, file.FileMd5, i);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            });
        }

        private async Task DownloadSingleFileAsnyc(string url,string savePath,string expectedHash,int index)
        {
            
            try
            {
                var fileModel = UpgradeFiles[index];
                var progress = new Progress<(long bytesDownloaded, long totalBytes)>(tuple =>
                {
                    fileModel.DownloadBytes = tuple.bytesDownloaded;
                    fileModel.Progress = (fileModel.DownloadBytes / tuple.totalBytes) * 100.0;
                    UpdateTotalProgress();
                });
                await httpService.DownloadFile(url, savePath, expectedHash, progress);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool downloadOver = false;
        /// <summary>
        /// 更新总下载进度
        /// </summary>
        private void UpdateTotalProgress()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                long downloadBytes = 0;
                int downloaded = 0;
                foreach (var file in UpgradeFiles)
                {
                    if (file.Progress == 100d && file.State == 0)
                    {
                        file.State = 1;
                        downloaded++;
                        DownloadFileSuccessHandler?.Invoke(this,new DownloadFileSuccessEventArgs(file));
                    }
                    downloadBytes += file.DownloadBytes;
                }

                if (downloaded > AlreadyCount)
                {
                    AlreadyCount = downloaded;
                }
                
                if (!downloadOver && AlreadyCount == UpgradeFiles.Count)
                {
                    downloadOver = true;
                    DownloadAllSuccessHandler?.Invoke(this,EventArgs.Empty);
                }
                DownloadProgress = Math.Round(downloadBytes / (double)totalBytes * 100, 2);
            });

        }
        #region INotifyPropertyChanged Implementation
        private void UpgradeFilesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion

        /// <summary>
        /// 下载完成，更新本地文件缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandlerFileDownloadSuccess(object sender, DownloadFileSuccessEventArgs e)
        {
            var file = e.DownloadFile;
            LocalFileBll.AddOrUpdate(file);
        }
    }
}