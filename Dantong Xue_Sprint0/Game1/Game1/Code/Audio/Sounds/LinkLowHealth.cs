using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class LinkLowHealth : ISounds
    {
        SoundEffect SFX;
        private static SoundEffectInstance instance;


        public LinkLowHealth()
        {
            SFX = AudioFactory.LoadLinkLowHealth();
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

