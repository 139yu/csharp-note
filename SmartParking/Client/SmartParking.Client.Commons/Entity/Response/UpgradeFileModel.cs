using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParking.Client.Commons.Entity.Response
{
    public class UpgradeFileModel
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileMd5 { get; set; }
        public long FileLen { get; set; }
        public string OutputDir { get; set; }
        public string UploadTime { get; set; }
        public int State { get; set; }
    }
}