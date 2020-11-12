
using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class SwordShoot : ISounds
    {
        SoundEffect swordShoot;
        private static SoundEffectInstance instance;


        public SwordShoot()
        {
            swordShoot = AudioFactory.LoadSwordShoot();
            instance = swordShoot.CreateInstance();
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

