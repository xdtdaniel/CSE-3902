using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class ArrowShoot : ISounds
    {
        SoundEffect SFX;
        private static SoundEffectInstance instance;


        public ArrowShoot()
        {
            SFX = AudioFactory.LoadArrowShoot();
            instance = SFX.CreateInstance();
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

