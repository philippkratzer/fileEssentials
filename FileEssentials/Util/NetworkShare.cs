using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FileEssentials.Util
{
    public class NetworkShare
    {
        [System.Runtime.InteropServices.DllImport("advapi32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        private WindowsImpersonationContext impersonatedUser = null;
        private object _CopyLock = new object();

        private string _user;
        private string _password;
        private string _domain;

        public NetworkShare()
        {
        }

        public NetworkShare(string user, string password, string domain)
        {
            _user = user;
            _password = password;
            _domain = domain;
        }

        /// <summary>
        /// This method will be called before an opration to login.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        private static WindowsImpersonationContext Login(string Username, string password, string domain)
        {
            IntPtr tokenHandle = new IntPtr(0);
            bool ret = LogonUser(Username, domain, password, 9, 0, ref tokenHandle);


            if (!ret)
                throw new Exception("Logon at networkshare failed.");

            System.Security.Principal.WindowsIdentity wid = new System.Security.Principal.WindowsIdentity(tokenHandle);
            return wid.Impersonate();
        }

        private void Impersonate(string Username, string password, string domain)
        {
            if (impersonatedUser == null)
            {
                impersonatedUser = Login(Username, password, domain);
            }
        }


        public bool Copy(string FileSource, string FileDest)
        {
            return Copy(_user, _password, _domain, FileSource, FileDest);
        }

        /// <summary>
        /// Copies a file from a networkshare to a given location. 
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <param name="FileSource"></param>
        /// <param name="FileDest"></param>
        public bool Copy(string Username, string password, string domain, string FileSource, string FileDest)
        {
            FileSource = ConvertHostnameToIP(FileSource);
            FileDest = ConvertHostnameToIP(FileDest);

            lock (_CopyLock)    //Lock it, because there happen some issues if multiple threads try to copy parallel.
            {
                try
                {
                    Impersonate(Username, password, domain);
                    File.Copy(FileSource, FileDest, true);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<string> GetFiles(string Path)
        {
            return GetFiles(_user, _password, _domain, Path);
        }

        /// <summary>
        /// Returns a list of all files of a networkshare
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public List<string> GetFiles(string Username, string password, string domain, string Path)
        {
            Path = ConvertHostnameToIP(Path);

            List<string> list = new List<string>();
            using (WindowsImpersonationContext impersonatedUser = Login(Username, password, domain))
            {
                try
                {
                    foreach (string p in Directory.GetFiles(Path))
                        list.Add(p);
                }
                finally
                {
                    impersonatedUser.Undo();
                }
            }
            return list;
        }

        public List<string> GetDirectories(string Path)
        {
            return GetDirectories(_user, _password, _domain, Path);
        }

        /// <summary>
        /// Returns a list of all directories of a networkshare
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public List<string> GetDirectories(string Username, string password, string domain, string Path)
        {
            Path = ConvertHostnameToIP(Path);
            List<string> list = new List<string>();
            using (WindowsImpersonationContext impersonatedUser = Login(Username, password, domain))
            {
                try
                {
                    foreach (string p in Directory.GetDirectories(Path))
                        list.Add(p);
                }
                finally
                {
                    impersonatedUser.Undo();
                }
            }
            return list;
        }

        public bool FileExists(string Path)
        {
            return FileExists(_user, _password, _domain, Path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <param name="Path"></param>
        /// <returns>true if file exists</returns>
        public bool FileExists(string Username, string password, string domain, string Path)
        {
            Path = ConvertHostnameToIP(Path);

            bool result = false;
            using (WindowsImpersonationContext impersonatedUser = Login(Username, password, domain))
            {
                try
                {
                    result = File.Exists(Path);
                }
                finally
                {
                    impersonatedUser.Undo();
                }
            }
            return result;
        }

        public string GetExtension(string path, string filename)
        {
            return GetExtension(_user, _password, _domain, path, filename);
        }

        /// <summary>
        /// If the extension of the file is unknown, this method tries to find the right extension by filename.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GetExtension(string Username, string password, string domain, string path, string filename)
        {
            path = ConvertHostnameToIP(path);
            using (WindowsImpersonationContext impersonatedUser = Login(Username, password, domain))
            {
                try
                {
                    foreach (string s in Directory.GetFiles(path))
                    {
                        FileInfo fi = new FileInfo(s);
                        string filename_without_extension = fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length);

                        if (filename_without_extension.ToLower() == filename.ToLower())
                            return fi.Extension.Replace(".", "");
                    }
                }
                finally { impersonatedUser.Undo(); }
            }
            return "";
        }

        public string CreateDirectory(string path)
        {
            return CreateDirectory(_user, _password, _domain, path);
        }

        /// <summary>
        /// If the extension of the file is unknown, this method tries to find the right extension by filename.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string CreateDirectory(string Username, string password, string domain, string path)
        {
            path = ConvertHostnameToIP(path);
            using (WindowsImpersonationContext impersonatedUser = Login(Username, password, domain))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                finally { impersonatedUser.Undo(); }
            }
            return "";
        }

        /// <summary>
        /// Converts a networkpath with hostnames to a networkpath with IPs, because the methods might have troubles with hostnames
        /// </summary>
        /// <param name="tmp_path"></param>
        /// <returns></returns>
        public static string ConvertHostnameToIP(string path)
        {
            try
            {
                string hostname;
                string tmp_path = path;

                tmp_path = tmp_path.Trim();
                if (!tmp_path.StartsWith(@"\\"))
                    return tmp_path;

                tmp_path = tmp_path.Remove(0, 2);

                if (tmp_path.Contains(@"\"))
                {
                    hostname = tmp_path.Substring(0, tmp_path.IndexOf(@"\"));
                    tmp_path = tmp_path.Remove(0, tmp_path.IndexOf(@"\") + 1);
                }
                else
                {
                    hostname = tmp_path;
                    tmp_path = "";
                }

                //it is already an IP
                if ((hostname.Contains('.')) && hostname.Split('.').Length == 4)
                    return path;


                return @"\\" + Dns.GetHostAddresses(hostname)[0].ToString() + @"\" + tmp_path;
            }
            catch (Exception) { return path; }
        }
    }
}
