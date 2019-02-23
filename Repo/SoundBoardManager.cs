using SoundBoard.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace SoundBoard.Repo
{
    public class SoundBoardManager
    {
        public SoundBoardObject[] Elements { get; set; }


        public SoundBoardManager(string JsonConfigFile)
        {
            if(File.Exists(JsonConfigFile))
                Elements = JsonConvert.DeserializeObject<SoundBoardObject[]>(File.ReadAllText(JsonConfigFile));
        }



        public Button[] ExtractButton()
        {
            Button[] buttons = new Button[Elements.Length];

            for (int i = 0; i < Elements.Length; i++)
            {
                Button button = new Button();
                button.Dock = System.Windows.Forms.DockStyle.Bottom;
                button.Location = new System.Drawing.Point(0, i * 100);
                button.Name = Elements[i].Name;
                button.Size = new System.Drawing.Size(100, 100);
                button.TabIndex = i;
                button.Text = Elements[i].Name;
                button.UseVisualStyleBackColor = true;
                button.Click += Button_Click;
                buttons[i] = button;

            }


            return buttons;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Elements.Where(c => c.Name == (sender as Button).Name).First().PlaySound();
        }

        public void BuildLayout()
        {

        }

        public void Load()
        {
            foreach(var el in Elements)
                el.OpenSound();
        }

        public void SaveSoundBoardConfig()
        {
            File.WriteAllText(@"config.json",JsonConvert.SerializeObject(Elements));
        }

    }
}
