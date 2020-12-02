using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerItem.PlayerItemSprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Player.Factory
{
    class PlayerAbilityFactory
    {
        private Texture2D blade;
        private Texture2D bladeEdge;
        private Texture2D slash;
        private Texture2D impact;
        private Texture2D bombExplosion;
        private Texture2D arrow;
        private Texture2D[] fireExplosion;
        private Texture2D[] burstRing;


        public static PlayerAbilityFactory Instance { get; } = new PlayerAbilityFactory();

        private PlayerAbilityFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {

            blade = content.Load<Texture2D>("PlayerAbility/Blade");
            bladeEdge = content.Load<Texture2D>("PlayerAbility/BladeEdge");
            slash = content.Load<Texture2D>("PlayerAbility/Slash");
            impact = content.Load<Texture2D>("PlayerAbility/Impact");
            bombExplosion = content.Load<Texture2D>("PlayerItemSprite/Bomb/BombExplosion");
            arrow = content.Load<Texture2D>("PlayerAbility/AbilityArrow");

            fireExplosion = new Texture2D[3];
            fireExplosion[0] = content.Load<Texture2D>("PlayerAbility/FireExplosion_0");
            fireExplosion[1] = content.Load<Texture2D>("PlayerAbility/FireExplosion_1");
            fireExplosion[2] = content.Load<Texture2D>("PlayerAbility/FireExplosion_2");

            burstRing = new Texture2D[3];
            burstRing[0] = content.Load<Texture2D>("PlayerAbility/BurstRing_0");
            burstRing[1] = content.Load<Texture2D>("PlayerAbility/BurstRing_1");
            burstRing[2] = content.Load<Texture2D>("PlayerAbility/BurstRing_2");
        }

        public Texture2D GetBlade()
        {
            return blade;
        }
        public Texture2D GetBladeEdge()
        {
            return bladeEdge;
        }
        public Texture2D GetSlash()
        {
            return slash;
        }
        public Texture2D GetImpact()
        {
            return impact;
        }
        public Texture2D GetBombExplosion()
        {
            return bombExplosion;
        }
        public Texture2D GetArrow()
        {
            return arrow;
        }
        public Texture2D[] GetFireExplosion()
        {
            return fireExplosion;
        }
        public Texture2D[] GetBurstRing()
        {
            return burstRing;
        }
    }
}