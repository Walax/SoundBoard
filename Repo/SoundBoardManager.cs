using SoundBoard.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Drawing;

namespace SoundBoard.Repo
{
    public class SoundBoardManager
    {
        public SoundBoardObject[] Elements { get; set; }


        public SoundBoardManager(string JsonConfigFile )
        {
            if(File.Exists(JsonConfigFile))
                Elements = JsonConvert.DeserializeObject<SoundBoardObject[]>(File.ReadAllText(JsonConfigFile));
        }

        public void AddElement(SoundBoardObject obj)
        {
            SoundBoardObject[] sobj = new SoundBoardObject[1];
            sobj[0] = obj;
            Elements = Elements.Concat(sobj).ToArray();

        }

        private Point TileMaker(int position)
        {
            int cols = 8;
            int cubeSize = 160;
            int yOffSet = 110;
            int xOffSet = 12;

            int yPos = (int)(position / cols);
            int xPos = yPos == 0 ? position : position - (yPos)  * cols;

            


               return new Point(xPos * cubeSize + xOffSet, (yPos* cubeSize) + yOffSet);

        }

        public Button[] ExtractButton()
        {
            Button[] buttons = new Button[Elements.Length];

            for (int i = 0; i < Elements.Length; i++)
            {
                Button button = new Button();
                button.Dock = System.Windows.Forms.DockStyle.None;
                button.Location = TileMaker(i);
                button.Name = Elements[i].Name;
                button.Size = new System.Drawing.Size(150, 150);
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
            File.WriteAllText(@"config.json",JsonConvert.SerializeObject(Elements, Formatting.Indented));
        }

    }
}
