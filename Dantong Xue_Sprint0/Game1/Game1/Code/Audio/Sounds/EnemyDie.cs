using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework.Audio;

namespace Game1.Code.Audio.Sounds
{
    class EnemyDie : ISounds
    {
        SoundEffect enemyDie;
        private static SoundEffectInstance instance;


        public EnemyDie()
        {
            enemyDie = AudioFactory.LoadEnemyDie();
            instance = enemyDie.CreateInstance();
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

