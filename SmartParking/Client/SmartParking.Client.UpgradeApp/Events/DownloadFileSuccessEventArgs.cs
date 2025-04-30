using System;
using SmartParking.Client.UpgradeApp.Models;

namespace SmartParking.Client.UpgradeApp.Events
{
    public class DownloadFileSuccessEventArgs: EventArgs
    {
        public UpgradeFileModel DownloadFile { get;}

        public DownloadFileSuccessEventArgs(UpgradeFileModel downloadFile)
        {
            DownloadFile = downloadFile;
        }
    }
}