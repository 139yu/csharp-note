namespace SmartParking.Client.Commons.Entity.Response
{
    public class FileVersion
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileMd5 { get; set; }
        public int FileLength { get; set; }
    }
}