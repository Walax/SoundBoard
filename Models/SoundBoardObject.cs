using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Media;

namespace SoundBoard.Models
{
    public class SoundBoardObject
    {
        MediaPlayer mp3Player;
        
        public SoundBoardObject()
        {
            mp3Player = new MediaPlayer();
        }
        public SoundBoardObject(string FilePath)
        {
            Mp3File = new Uri(FilePath);
            Name = Path.ChangeExtension(Path.GetFileName(FilePath), "");
        }

        public Uri Mp3File { get; set; }
        public Image Thumbnail { get;set;}
        public string Name { get; set; }
        public double Volume { get; set; }
        public void OpenSound()
        {
            mp3Player.Open(Mp3File);
        }
        public void PlaySound()
        {
            mp3Player.Open(Mp3File);
            mp3Player.Volume = Volume == 0 ? 0.5 : Volume;
            mp3Player.Play();
        }
        public void StopSound()
        {
            mp3Player.Stop();
        }
    }
}
