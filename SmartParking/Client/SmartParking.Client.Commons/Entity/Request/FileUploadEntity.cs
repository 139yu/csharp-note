using System.Collections.Generic;
using System.IO;

namespace SmartParking.Client.Commons.Entity.Request
{
    public class FileUploadEntity
    {
        public string FileName { get; set; }
        /*public string FileMd5 { get; set; }
        public string OutputDir { get; set; }*/
        public Stream FileContent { get; set; }
        public string ContentType { get; set; } = "application/octet-stream";
        private Dictionary<string, string> _fileMetadata;
        public Dictionary<string, string> FileMetadata
        {
            get
            {
                if (_fileMetadata == null)
                {
                    _fileMetadata = new Dictionary<string, string>();
                }

                return _fileMetadata;
            }
        }

        public void Put(string key,string val)
        {
            FileMetadata.Add(key,val);
        }
    }
}