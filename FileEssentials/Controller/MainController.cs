using FileEssentials.Model;
using FileEssentials.View;
using System;
using System.Collections.Generic;
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
            Application.Run(_view);
        }
    }
}
