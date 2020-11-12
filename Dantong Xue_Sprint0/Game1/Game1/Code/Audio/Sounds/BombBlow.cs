
using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class BombBlow : ISounds
    {
        SoundEffect bombBlow;
        private static SoundEffectInstance instance;


        public BombBlow()
        {
            bombBlow = AudioFactory.LoadBombBlow();
            instance = bombBlow.CreateInstance();
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

