using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class GetTriforce : ISounds
    {
        SoundEffect getTriforce;
        private static SoundEffectInstance instance;


        public GetTriforce()
        {
            getTriforce = AudioFactory.LoadGetTriforce();
            instance = getTriforce.CreateInstance();
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

