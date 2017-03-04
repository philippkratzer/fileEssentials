using FileEssentials.Controller;
using FileEssentials.Model;
using FileEssentials.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileEssentials
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new FormMain();
            var model = new MainModel();
            var controller = new MainController(model, view);

            controller.StartApplication();
        }
    }
}
