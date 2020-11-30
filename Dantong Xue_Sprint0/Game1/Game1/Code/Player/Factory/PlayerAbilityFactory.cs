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
    }
}