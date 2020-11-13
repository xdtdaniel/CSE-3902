using Game1.Code.Audio.Sounds;

namespace Game1.Code.Audio
{
    class Audio
    {
        private ISounds bgm;
        public Audio(Game1 game)
        {
            bgm = new BGM();
        }

        public void AudioLoad()
        {
            bgm.Play();
        }
        public void AudioUpdate()
        {
            
        }
    }
}
