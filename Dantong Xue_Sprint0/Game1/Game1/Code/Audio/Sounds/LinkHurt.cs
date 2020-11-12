using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class LinkHurt : ISounds
    {
        SoundEffect linkHurt;
        private static SoundEffectInstance instance;


        public LinkHurt()
        {
            linkHurt = AudioFactory.LoadLinkHurt();
            instance = linkHurt.CreateInstance();
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

