
using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class BombDrop : ISounds
    {
        SoundEffect bombDrop;
        private static SoundEffectInstance instance;


        public BombDrop()
        {
            bombDrop = AudioFactory.LoadBombDrop();
            instance = bombDrop.CreateInstance();
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

