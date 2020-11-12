using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class EnemyHit : ISounds
    {
        SoundEffect enemyHit;
        private static SoundEffectInstance instance;


        public EnemyHit()
        {
            enemyHit = AudioFactory.LoadEnemyHit();
            instance = enemyHit.CreateInstance();
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

