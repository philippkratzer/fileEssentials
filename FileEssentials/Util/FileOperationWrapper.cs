using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEssentials.Util
{
    public class FileOperationWrapper
    {
        private NetworkShare _networkShare;

        public FileOperationWrapper()
        {

        }

        public FileOperationWrapper(NetworkShare networkShare)
        {
            _networkShare = networkShare;
        }

        public List<string> GetDirectories(string path)
        {
            if (path.StartsWith(@"\\"))
                return _networkShare.GetDirectories(path);
            else
                return Directory.GetDirectories(path).ToList();
        }

        public List<string> GetFiles(string path)
        {
            if (path.StartsWith(@"\\"))
                return _networkShare.GetFiles(path);
            else
                return Directory.GetFiles(path).ToList();
        }

        public bool FileExists(string path)
        {
            if (path.StartsWith(@"\\"))
                return _networkShare.FileExists(path);
            else
                return File.Exists(path);
        }

        public void FileCopy(string src, string dest)
        {
            if (src.StartsWith(@"\\") || dest.StartsWith(@"\\"))
                _networkShare.Copy(src, dest);
            else
                File.Copy(src,dest);
        }

        public void CreateDirectory(string path)
        {
            if (path.StartsWith(@"\\"))
                _networkShare.CreateDirectory(path);
            else
                Directory.CreateDirectory(path);
        }
    }
}
