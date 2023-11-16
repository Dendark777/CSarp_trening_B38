using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.FtpClient;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests.AppManager
{
    public class FtpHelper : HelperBase
    {
        private readonly FtpClient _client;
        public FtpHelper(ApplicationManager manager) : base(manager)
        {
            _client = new FtpClient();
            _client.Host = "localhost";
            _client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            _client.Connect();
        }

        public void BackupFile(string path)
        {
            string backupPath = path + ".bak";
            if (_client.FileExists(backupPath))
            {
                return;
            }
            _client.Rename(path, backupPath);
        }

        public void RestoreBackupFile(string path)
        {
            string backupPath = path + ".bak";
            if (!_client.FileExists(backupPath))
            {
                return;
            }
            if (_client.FileExists(path))
            {
                _client.DeleteFile(path);
            }
            _client.Rename(backupPath, path);
        }

        public void Upload(string path, Stream localFile)
        {
            if (_client.FileExists(path))
            {
                _client.DeleteFile(path);
            }
            using (Stream ftpStream = _client.OpenWrite(path))
            {
                byte[] buffer = new byte[8 * 1024];
                int count =  localFile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localFile.Read(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
