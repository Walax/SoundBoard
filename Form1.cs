using SoundBoard.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace SoundBoard
{
    public partial class Form1 : Form
    {
        SoundBoardManager manager;

        public Form1()
        {
            
            manager = new SoundBoardManager("config.json");
            buttonLayout();
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLayout()
        {


            this.Controls.AddRange(manager.ExtractButton());
        }


        private void ButtonExit_Click(object sender, System.EventArgs e)
        {
            manager.SaveSoundBoardConfig();
        }
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
