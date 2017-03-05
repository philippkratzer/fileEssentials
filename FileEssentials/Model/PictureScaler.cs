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

                foreach (var file in _fileOperation.GetFiles(path))
                    ProcessFile(file);
            }

        }

        private void ProcessFile(string path)
        {
            var fiSource = new FileInfo(path);

            if (fiSource.Extension.ToLower() != ".jpg" && fiSource.Extension.ToLower() != "jpeg")
                return;

            var relativeSrc = fiSource.DirectoryName.Substring(_pathPictures.Length);
            if (relativeSrc.StartsWith(@"\"))
                relativeSrc = relativeSrc.Substring(1);

            var pathDest = Path.Combine(_pathDestination, relativeSrc, fiSource.Name);

            //Check if file is already processed.
            if (_fileOperation.FileExists(pathDest))
            {
                Logging.Log($"SKIPPED: {path}", this, LoggingType.Status, 3);
                FileSkippedEvent?.Invoke(this, ++_filesSkipped);
                return;
            }

            Logging.Log($"ADD: {path}", this, LoggingType.Status, 3);
            var pathTemp = Path.Combine(_pathTemp, fiSource.Name);
            var pathTempNew = Path.Combine(_pathTemp, fiSource.Name + "processed");
            try
            {
                //file needs to be processed. copy the file to a local dir
                _fileOperation.FileCopy(fiSource.FullName, pathTemp);

                ImageUtil.ResizeFile(pathTemp, pathTempNew, Settings.Default.LongSideLength);

                var fiDestination = new FileInfo(pathDest);
                _fileOperation.CreateDirectory(fiDestination.DirectoryName);
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
