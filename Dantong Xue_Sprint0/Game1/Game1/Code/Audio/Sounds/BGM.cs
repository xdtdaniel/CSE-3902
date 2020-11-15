using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class BGM : ISounds
    {
        SoundEffect song;
        private static SoundEffectInstance instance;

        public BGM()
        {
            song = AudioFactory.LoadBgm();
            instance = song.CreateInstance();
    }
        public void Play()
        {
            instance.Play();
            instance.IsLooped = true;
        }

        public void Stop()
        {
            instance.Stop();
        }
    }
}
