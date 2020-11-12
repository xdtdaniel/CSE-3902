
using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class DoorUnlock : ISounds
    {
        SoundEffect doorUnlock;
        private static SoundEffectInstance instance;


        public DoorUnlock()
        {
            doorUnlock = AudioFactory.LoadDoorUnlock();
            instance = doorUnlock.CreateInstance();
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

