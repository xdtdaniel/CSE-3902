using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class GetHeart : ISounds
    {
        SoundEffect getHeart;
        private static SoundEffectInstance instance;


        public GetHeart()
        {
            getHeart = AudioFactory.LoadGetHeart();
            instance = getHeart.CreateInstance();
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

