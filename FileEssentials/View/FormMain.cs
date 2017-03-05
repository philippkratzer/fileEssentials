using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileEssentials.View
{
    public partial class FormMain : Form
    {
        public string PathPictures { get { return textBoxPathPictures.Text; } set { textBoxPathPictures.Text = value; } }
        public string PathDestination { get { return textBoxPathDestination.Text; } set { textBoxPathDestination.Text = value; } }
        public List<string> Blacklist { get { return listBoxBlacklist.Items.Cast<string>().ToList(); } set { listBoxBlacklist.DataSource = value; } }
        public int LongSideLength { get { return (int)numericUpDownSize.Value; } set { numericUpDownSize.Value = value; } }

        public int AddedFiles { set { UpdateAddedFiles(value); } }
        public int SkippedFiles { set { UpdateSkippedFiles(value); } }

        public event EventHandler StartRequestEvent;
        public event EventHandler LoadRequestEvent;
        public event EventHandler SaveRequestEvent;
        public event EventHandler ExitRequestEvent;

        public FormMain()
        {
            InitializeComponent();
            UpdateAddedFiles(0);
            UpdateSkippedFiles(0);
        }

        private void UpdateAddedFiles(int i)
        {
            MethodInvoker invoker = () => { labelAddedFiles.Text = i.ToString(); };
            if (this.InvokeRequired) this.Invoke(invoker);
            else invoker.Invoke();
        }

        private void UpdateSkippedFiles(int i)
        {
            MethodInvoker invoker = () => { labelSkippedFiles.Text = i.ToString(); };
            if (this.InvokeRequired) this.Invoke(invoker);
            else invoker.Invoke();
        }

        private void buttonBrowsePictures_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPathPictures.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonBrowseDestination_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPathDestination.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonBrowseBlacklist_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxBlacklist.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonAddBlacklist_Click(object sender, EventArgs e)
        {
            string path = textBoxBlacklist.Text.Trim();

            //not contains case insensitive
            if (Blacklist.FindIndex(x => x.Equals(path, StringComparison.InvariantCultureIgnoreCase)) == -1)
            {
                listBoxBlacklist.Items.Add(path);
                textBoxBlacklist.Text = "";
            }
        }

        private void buttonRemoveBlacklist_Click(object sender, EventArgs e)
        {
            if (listBoxBlacklist.SelectedIndex >= 0 && listBoxBlacklist.SelectedIndex <= listBoxBlacklist.Items.Count && listBoxBlacklist.Items.Count > 0)
            {
                listBoxBlacklist.Items.RemoveAt(listBoxBlacklist.SelectedIndex);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadRequestEvent?.Invoke(this, null);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRequestEvent?.Invoke(this, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitRequestEvent?.Invoke(this, null);
        }
    }
}
