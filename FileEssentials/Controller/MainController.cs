using FileEssentials.Model;
using FileEssentials.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileEssentials.Controller
{
    class MainController
    {
        MainModel _model;
        FormMain _view;
        public MainController(MainModel model, FormMain view)
        {
            _model = model;
            _view = view;
        }

        public void StartApplication()
        {
            Init();
            Application.Run(_view);
        }

        private void Init()
        {
            RegisterEvents();
            LoadSettings();
        }

        private void RegisterEvents()
        {
            _view.ExitRequestEvent += ButtonExit_Click;
            _view.LoadRequestEvent += ButtonLoad_Click;
            _view.SaveRequestEvent += ButtonSave_Click;
            _view.StartRequestEvent += ButtonStart_Click;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            try
            {
                PictureScaler scaler = new PictureScaler(_view.PathPictures, _view.PathDestination, _view.Blacklist, _view.LongSideLength);
                scaler.FileAddedEvent += Scaler_FileAddedEvent;
                scaler.FileSkippedEvent += Scaler_FileSkippedEvent;
                scaler.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to process. Exception: {ex.Message}");
            }
        }

        private void Scaler_FileSkippedEvent(object sender, int e)
        {
            _view.SkippedFiles = e;
        }

        private void Scaler_FileAddedEvent(object sender, int e)
        {
            _view.AddedFiles = e;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LoadSettings()
        {
            Settings.DeserializeFile();

            _view.PathPictures = Settings.Default.PathPictures;
            _view.PathDestination = Settings.Default.PathDestination;
            _view.Blacklist = Settings.Default.Blacklist;
            _view.LongSideLength = Settings.Default.LongSideLength;
        }

        private void SaveSettings()
        {
            Settings.Default.PathPictures = _view.PathPictures;
            Settings.Default.PathDestination = _view.PathDestination;
            Settings.Default.Blacklist = _view.Blacklist;
            Settings.Default.LongSideLength = _view.LongSideLength;

            Settings.SerializeFile();
        }
    }
}
