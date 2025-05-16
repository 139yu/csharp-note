using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace SmartParking.Client.SystemModule.Models
{
    public class FileUploadModel: BindableBase
    {
        public int Index { get; set; }
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string OutputDir { get; set; }

        private string _state;
        public string State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }
    }
}