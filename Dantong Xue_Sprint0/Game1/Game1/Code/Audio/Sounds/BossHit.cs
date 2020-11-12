
using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class BossScream : ISounds
    {
        SoundEffect SFX;
        private static SoundEffectInstance instance;


        public BossScream()
        {
            SFX = AudioFactory.LoadBossScream();
            instance = SFX.CreateInstance();
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

