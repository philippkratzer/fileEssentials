using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileEssentials.Util;
using System.Drawing;
using System.ComponentModel;
using FileEssentials.Util.Log;

namespace FileEssentials.Model
{
    class PictureScaler
    {
        private string _pathPictures;
        private string _pathDestination;
        private string _pathTemp = @"C:\temp\FileEssentials\PictureScaler";
        private List<string> _blacklist;
        private int _longSideLengt;

        private bool _sourceIsNetworkShare;
        private bool _destinationIsNetworkShare;

        FileOperationWrapper _fileOperation;

        public event EventHandler<int> FileAddedEvent;
        public event EventHandler<int> FileSkippedEvent;

        private int _filesSkipped = 0;
        private int _filesAdded = 0;

        public PictureScaler(string pathPictures, string pathDestination, List<string> blacklist, int longSideLength)
        {
            _pathPictures = new DirectoryInfo(pathPictures).FullName;
            _pathDestination = new DirectoryInfo(pathDestination).FullName;
            _blacklist = blacklist;
            _longSideLengt = longSideLength;
        }

        private void Setup()
        {
            if (_pathPictures.StartsWith(@"\\"))
                _sourceIsNetworkShare = true;

            if (_pathDestination.StartsWith(@"\\"))
                _destinationIsNetworkShare = true;

            if (_sourceIsNetworkShare || _destinationIsNetworkShare)
                _fileOperation = new FileOperationWrapper(new NetworkShare(Settings.Default.NasUser, Settings.Default.NasPassword, Settings.Default.NasDomain));
            else
                _fileOperation = new FileOperationWrapper();

            Directory.CreateDirectory(_pathTemp);
        }

        public void StartAsync()
        {
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += Bgw_DoWork;
            bgw.RunWorkerAsync();
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Start();
        }

        public void Start()
        {
            Setup();
            Logging.Log("Start.", this, LoggingType.Status, 1);
            ProcessPath(_pathPictures);
            Logging.Log("End.", this, LoggingType.Status, 1);
        }

        private void ProcessPath(string path)
        {
            //check if path is blacklisted
            if (_blacklist.FindIndex(x => x.Equals(path, StringComparison.InvariantCultureIgnoreCase)) >= 0)
            {
                Logging.Log($"BLACKLISTED: {path}", this, LoggingType.Status, 3);
                return;
            }

            if (_sourceIsNetworkShare)
            {
                foreach (var dir in _fileOperation.GetDirectories(path))
                    ProcessPath(dir);

                foreach (var file in GetFilesQueue(path))
                {
                    try
                    {
                        ProcessFile(file);
                    }
                    catch (Exception ex)
                    {
                        Logging.Log($"ERROR: {path}. Exception: {ex.Message}", this, LoggingType.Status, 3);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a list of paths to files which have to be processed (unprocessed will be removed).
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<string> GetFilesQueue(string path)
        {
            List<string> list = new List<string>();

            //get a list of files in src ...
            var fiSource = new DirectoryInfo(path);
            var relativeSrc = fiSource.FullName.Substring(_pathPictures.Length);
            if (relativeSrc.StartsWith(@"\"))
                relativeSrc = relativeSrc.Substring(1);

            var pathDest = Path.Combine(_pathDestination, relativeSrc);

            //get a list of files in dest.
            var listSrc = _fileOperation.GetFiles(path);
            var listDest = new List<string>();

            if (_fileOperation.DirectoryExists(pathDest))
                listDest = _fileOperation.GetFiles(pathDest);

            var lookuptable = new HashSet<string>();
            foreach (var file in listDest)
            {
                lookuptable.Add(new FileInfo(file).Name);
            }

            //... and compare which files are already existing in dest
            foreach (var file in listSrc)
            {
                var filenameSrc = new FileInfo(file);

                if (filenameSrc.Extension.ToLower() != ".jpg" && filenameSrc.Extension.ToLower() != "jpeg")
                    continue;

                if (lookuptable.Contains(filenameSrc.Name))
                {
                    Logging.Log($"SKIPPED: {path}", this, LoggingType.Status, 3);
                    FileSkippedEvent?.Invoke(this, ++_filesSkipped);
                }
                else
                {
                    list.Add(file);
                }
            }
            return list;
        }

        private void ProcessFile(string path)
        {
            var fiSource = new FileInfo(path);

            Logging.Log($"ADD: {path}", this, LoggingType.Status, 3);
            var pathTemp = Path.Combine(_pathTemp, fiSource.Name);
            var pathTempNew = Path.Combine(_pathTemp, fiSource.Name + "processed");

            var relativeSrc = fiSource.DirectoryName.Substring(_pathPictures.Length);
            if (relativeSrc.StartsWith(@"\"))
                relativeSrc = relativeSrc.Substring(1);
            var pathDest = Path.Combine(_pathDestination, relativeSrc);

            try
            {
                //file needs to be processed. copy the file to a local dir
                _fileOperation.FileCopy(fiSource.FullName, pathTemp);

                ImageUtil.ResizeFile(pathTemp, pathTempNew, Settings.Default.LongSideLength);

                _fileOperation.CreateDirectory(pathDest);
                pathDest = Path.Combine(pathDest, fiSource.Name);
                _fileOperation.FileCopy(pathTempNew, pathDest);
            }
            finally
            {
                if (File.Exists(pathTemp))
                    File.Delete(pathTemp);

                if (File.Exists(pathTempNew))
                    File.Delete(pathTempNew);
            }

            FileAddedEvent?.Invoke(this, ++_filesAdded);
        }
    }
}
