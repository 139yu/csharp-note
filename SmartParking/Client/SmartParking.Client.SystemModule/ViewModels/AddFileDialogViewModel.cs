using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using ImTools;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SmartParking.Client.Commons.Entity.Request;
using SmartParking.Client.Commons.Helper;
using SmartParking.Client.IBLL;
using SmartParking.Client.SystemModule.Models;

namespace SmartParking.Client.SystemModule.ViewModels
{
    public class AddFileDialogViewModel : BindableBase, IDialogAware
    {
        private IFileBll _fileBll;

        public AddFileDialogViewModel(IFileBll fileBll)
        {
            _fileBll = fileBll;
        }

        private ObservableCollection<FileUploadModel> _fileModels;

        public ObservableCollection<FileUploadModel> FileUploadList
        {
            get
            {
                if (_fileModels == null)
                {
                    _fileModels = new ObservableCollection<FileUploadModel>();
                }

                return _fileModels;
            }
            set => SetProperty(ref _fileModels, value);
        }

        private ICommand _selectFileCommand;
        private ICommand _uploadFileCommand;

        public ICommand SelectFileCommand
        {
            get
            {
                if (_selectFileCommand == null)
                {
                    _selectFileCommand = new DelegateCommand(DoSelectFile);
                }

                return _selectFileCommand;
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
            if (FileUploadList != null && FileUploadList.Count == 0)
            {
                MessageBox.Show("请选择文件", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Task.Run(async () =>
            {
                foreach (var file in FileUploadList)
                {
                    
                    try
                    {
                        Dictionary<string, string> metadata = new Dictionary<string, string>();
                        metadata.Add("outputDir", file.OutputDir);
                        metadata.Add("filename", file.FileName);
                        metadata.Add("fileMd5", FileUtils.GetFileMd5(file.FullPath));
                        var res = await _fileBll.UploadFile(file.FullPath, metadata, progress =>
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                file.State = progress + "%";
                            });
                        });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
            });
        }

        private void DoSelectFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == true)
            {
                FileUploadList.Clear();
                if (fileDialog.FileNames.Length > 0)
                {
                    for (var i = 0; i < fileDialog.FileNames.Length; i++)
                    {
                        var file = fileDialog.FileNames[i];
                        FileUploadList.Add(new FileUploadModel()
                        {
                            Index = i + 1,
                            FileName = new FileInfo(file).Name,
                            FullPath = file,
                            State = "待上传"
                        });
                    }
                }
            }
        }

        #region DialogAware

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public string Title { get; } = "文件上传";
        public event Action<IDialogResult> RequestClose;

        #endregion
    }
}