using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace SmartParking.Client.UpgradeApp.Models
{
    public class UpgradeFileModel: INotifyPropertyChanged
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileMd5 { get; set; }
        public long FileLen { get; set; }
        public string UploadTime { get; set; }
        public int State { get; set; }
        private long downloadByted = 0;

        public long DownloadBytes
        {
            get => downloadByted;
            set
            {
                if (downloadByted != value)
                {
                    downloadByted = value;
                    OnPropertyChanged(nameof(DownloadBytes));
                }
            }
        }
        private double progress = 0;
        public double Progress
        {
            get => progress;
            set
            {
                if (progress != value)
                {
                    progress = value;
                    OnPropertyChanged(nameof(Progress));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}