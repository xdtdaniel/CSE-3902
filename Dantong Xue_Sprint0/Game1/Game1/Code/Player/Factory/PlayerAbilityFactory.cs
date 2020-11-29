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


        public static PlayerAbilityFactory Instance { get; } = new PlayerAbilityFactory();

        private PlayerAbilityFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {

            blade = content.Load<Texture2D>("PlayerAbility/Blade");
            bladeEdge = content.Load<Texture2D>("PlayerAbility/BladeEdge");
            slash = content.Load<Texture2D>("PlayerAbility/Slash");
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
    }
}