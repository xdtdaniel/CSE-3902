using Game1.Code.Audio.Sounds;

namespace Game1.Code.Audio
{
    public static class AudioPlayer
    {
        public static ISounds arrowShoot = new ArrowShoot();
        public static ISounds bgm = new BGM();
        public static ISounds bombBlow = new BombBlow();
        public static ISounds bombDrop = new BombDrop();
        public static ISounds bossHit = new BossHit();
        public static ISounds bossScream = new BossScream();
        public static ISounds doorUnlock = new DoorUnlock();
        public static ISounds enemyDie = new EnemyDie();
        public static ISounds enemyHit = new EnemyHit();
        public static ISounds getHeart = new GetHeart();
        public static ISounds getItem = new GetItem();
        public static ISounds getRupee = new GetRupee();
        public static ISounds getTriforce = new GetTriforce();
        public static ISounds linkDead = new LinkDead();
        public static ISounds linkHurt = new LinkHurt();
        public static ISounds linkLowHealth = new LinkLowHealth();
        public static ISounds swordShoot = new SwordShoot();
        public static ISounds swordSlash = new SwordSlash();
    }
}
