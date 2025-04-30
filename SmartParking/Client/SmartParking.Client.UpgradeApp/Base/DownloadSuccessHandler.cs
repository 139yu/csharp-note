using System;
using SmartParking.Client.UpgradeApp.Events;

namespace SmartParking.Client.UpgradeApp.Base
{
    public delegate void DownloadFileSuccessHandler(object sender,DownloadFileSuccessEventArgs e);

    public delegate void DownloadAllSuccessHandler(object sender,EventArgs e);
}