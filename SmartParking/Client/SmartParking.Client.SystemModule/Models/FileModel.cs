using System.Windows.Input;
using Prism.Mvvm;

namespace SmartParking.Client.SystemModule.Models
{
    public class FileModel
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string OutputDir { get; set; }
        public string UploadTime { get; set; }
        public string State { get; set; }
        public ICommand DeleteCommand { get; set; }
    }
}