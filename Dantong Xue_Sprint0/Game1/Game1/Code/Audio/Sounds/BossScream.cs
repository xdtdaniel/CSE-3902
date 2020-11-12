
using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class BossHit : ISounds
    {
        SoundEffect SFX;
        private static SoundEffectInstance instance;


        public BossHit()
        {
            SFX = AudioFactory.LoadBossHit();
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

