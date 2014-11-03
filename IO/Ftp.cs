using System.Configuration;
using System.IO;
using System.Net;

namespace LabOfClouds.Library.IO
{
    public static class Ftp
    {
        public static bool Upload(FileInfo file)
        {
            try
            {
                string uploadUrl = ConfigurationManager.AppSettings["FtpAddress"];
                string username = ConfigurationManager.AppSettings["FtpUser"];
                string password = ConfigurationManager.AppSettings["FtpPass"];

                var ftpClient = (FtpWebRequest)WebRequest.Create(uploadUrl + file.Name);
                ftpClient.Credentials = new NetworkCredential(username, password);
                ftpClient.Method = WebRequestMethods.Ftp.UploadFile;
                ftpClient.UseBinary = true;
                ftpClient.KeepAlive = true;
                ftpClient.ContentLength = file.Length;

                var buffer = new byte[4097];
                var totalBytes = (int)file.Length;
                var fs = file.OpenRead();
                var rs = ftpClient.GetRequestStream();

                while (totalBytes > 0)
                {
                    int bytes = fs.Read(buffer, 0, buffer.Length);
                    rs.Write(buffer, 0, bytes);
                    totalBytes = totalBytes - bytes;
                }

                fs.Close();
                rs.Close();
                var uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
                uploadResponse.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}