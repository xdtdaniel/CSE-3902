using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class LinkDead : ISounds
    {
        SoundEffect linkDead;
        private static SoundEffectInstance instance;


        public LinkDead()
        {
            linkDead = AudioFactory.LoadLinkDead();
            instance = linkDead.CreateInstance();
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

