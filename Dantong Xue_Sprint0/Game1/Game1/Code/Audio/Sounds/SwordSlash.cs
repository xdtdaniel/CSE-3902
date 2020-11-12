
using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class SwordSlash : ISounds
    {
        SoundEffect swordSlash;
        private static SoundEffectInstance instance;


        public SwordSlash()
        {
            swordSlash = AudioFactory.LoadSwordSlash();
            instance = swordSlash.CreateInstance();
        }
        public void Play()
        {
            instance.Play();
        }

        public void Stop()
        {
            instance.Stop();
        }
    }
}

