using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class GetItem : ISounds
    {
        SoundEffect getItem;
        private static SoundEffectInstance instance;


        public GetItem()
        {
            getItem = AudioFactory.LoadGetItem();
            instance = getItem.CreateInstance();
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

