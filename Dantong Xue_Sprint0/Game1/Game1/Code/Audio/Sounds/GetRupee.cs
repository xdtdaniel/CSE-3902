using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class GetRupee : ISounds
    {
        SoundEffect getRupee;
        private static SoundEffectInstance instance;


        public GetRupee()
        {
            getRupee = AudioFactory.LoadGetRupee();
            instance = getRupee.CreateInstance();
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

