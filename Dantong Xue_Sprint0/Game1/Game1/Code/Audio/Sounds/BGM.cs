using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Media;

namespace Game1.Code.Audio.Sounds
{
    class BGM : ISounds
    {
        Song song;


        public BGM()
        {
            song = AudioFactory.LoadBgm();
    }
        public void Play()
        {            
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        public void Stop()
        {
            MediaPlayer.Stop();
        }
    }
}
