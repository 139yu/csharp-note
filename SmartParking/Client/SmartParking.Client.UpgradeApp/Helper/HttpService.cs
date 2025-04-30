using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SmartParking.Client.UpgradeApp.Helper
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
            _httpClient.MaxResponseContentBufferSize = int.MaxValue;
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="savePath"></param>
        /// <param name="exceptHash">校验文件md5</param>
        /// <param name="progress"></param>
        /// <param name="ct"></param>
        public async Task DownloadFile(string url,string savePath,string exceptHash,IProgress<(long bytesDonwloaded,long totalBytes)> progress, CancellationToken ct = default)
        {
            using (var response = await _httpClient.GetAsync(url,HttpCompletionOption.ResponseHeadersRead,ct))
            {
                // 检查HttpResponseMessage的StatusCode属性，如果不在响应成功范围内，抛出异常
                try
                {
                    response.EnsureSuccessStatusCode();
                    var totalBytes = response.Content.Headers.ContentLength ?? 0;
                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var fileStream = new FileStream(savePath, FileMode.Create,FileAccess.Write))
                        {
                            var buffer = new byte[1024 * 8 * 1024];
                            var totalRead = 0L;
                            var bytesRead = 0;
                            while ((bytesRead = contentStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead), ct);
                                totalRead += bytesRead;
                                if (totalBytes > 0)
                                {
                                    progress.Report((totalRead, totalBytes));
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            // 校验文件哈希
            
        }

       
    }
}