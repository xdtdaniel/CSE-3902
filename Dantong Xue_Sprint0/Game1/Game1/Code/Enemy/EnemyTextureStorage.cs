using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public static class EnemyTextureStorage
    {
        private static Texture2D gelSpriteSheet;
        private static Texture2D keeseSpriteSheet;
        private static Texture2D stalfosSpriteSheet;
        private static Texture2D goriyaSpriteSheet;
        private static Texture2D goriyaProjectileSpriteSheet;

        private static Texture2D wallmaster0SpriteSheet;
        private static Texture2D wallmaster1SpriteSheet;
        private static Texture2D wallmaster3SpriteSheet;

        private static Texture2D aquamentusSpriteSheet;
        private static Texture2D aquamentusProjectileSpriteSheet;
        private static Texture2D oldManSpriteSheet;
        private static Texture2D merchantSpriteSheet;
        private static Texture2D fireSpriteSheet;
        private static Texture2D trapSpriteSheet;

        private static Texture2D newtrapSpriteSheet;
        private static Texture2D newtrap1SpriteSheet;
        private static Texture2D aquamentusBatProjectileSheet;
        private static Texture2D sawSpriteSheet;
        private static Texture2D burningSawSpriteSheet;
        private static Texture2D freezingSawSpriteSheet;

        public static void LoadTextures(ContentManager content) {
            gelSpriteSheet = content.Load<Texture2D>("Sprite/enemies/gel_sprite");
            keeseSpriteSheet = content.Load<Texture2D>("Sprite/enemies/keese_sprite");
            stalfosSpriteSheet = content.Load<Texture2D>("Sprite/enemies/stalfos_sprite");
            goriyaSpriteSheet = content.Load<Texture2D>("Sprite/enemies/goriya_sprite");
            goriyaProjectileSpriteSheet = content.Load<Texture2D>("Sprite/enemies/goriya_projectile_sprite");

            wallmaster0SpriteSheet = content.Load<Texture2D>("Sprite/enemies/wallmaster0_sprite");
            wallmaster1SpriteSheet = content.Load<Texture2D>("Sprite/enemies/wallmaster1_sprite");
            wallmaster3SpriteSheet = content.Load<Texture2D>("Sprite/enemies/wallmaster3_sprite");

            aquamentusSpriteSheet = content.Load<Texture2D>("Sprite/enemies/aquamentus_sprite");
            aquamentusProjectileSpriteSheet = content.Load<Texture2D>("Sprite/enemies/aquamentus_projectile_sprite");
            oldManSpriteSheet = content.Load<Texture2D>("Sprite/npcs/oldman_sprite");
            merchantSpriteSheet = content.Load<Texture2D>("Sprite/npcs/merchant_sprite");
            fireSpriteSheet = content.Load<Texture2D>("Sprite/npcs/fire_sprite"); 
            trapSpriteSheet = content.Load<Texture2D>("Sprite/enemies/trap_sprite");

            newtrapSpriteSheet = content.Load<Texture2D>("Sprite/enemies/newtrap_sprite");
            newtrap1SpriteSheet = content.Load<Texture2D>("Sprite/enemies/newtrap1_sprite");
            aquamentusBatProjectileSheet = content.Load<Texture2D>("Sprite/enemies/redbat_sprite");
            sawSpriteSheet = content.Load<Texture2D>("Sprite/enemies/saw_sprite");
            burningSawSpriteSheet = content.Load<Texture2D>("Sprite/enemies/burning_saw_sprite");
            freezingSawSpriteSheet = content.Load<Texture2D>("Sprite/enemies/freezing_saw_sprite");
        }

        public static Texture2D GetGelSpriteSheet() {
            return gelSpriteSheet;
        }

        public static Texture2D GetKeeseSpriteSheet() {
            return keeseSpriteSheet;
        }

        public static Texture2D GetStalfosSpriteSheet()
        {
            return stalfosSpriteSheet;
        }

        public static Texture2D GetGoriyaSpriteSheet()
        {
            return goriyaSpriteSheet;
        }

        public static Texture2D GetGoriyaProjectileSpriteSheet()
        {
            return goriyaProjectileSpriteSheet;
        }

        public static Texture2D GetAquamentusSpriteSheet()
        {
            return aquamentusSpriteSheet;
        }

        public static Texture2D GetAquamentusProjectileSpriteSheet()
        {
            return aquamentusProjectileSpriteSheet;
        }

        public static Texture2D GetWallmaster0SpriteSheet()
        {
            return wallmaster0SpriteSheet;
        }

        public static Texture2D GetWallmaster1SpriteSheet()
        {
            return wallmaster1SpriteSheet;
        }

        public static Texture2D GetWallmaster3SpriteSheet()
        {
            return wallmaster3SpriteSheet;
        }

        public static Texture2D GetOldManSpriteSheet()
        {
            return oldManSpriteSheet;
        }

        public static Texture2D GetMerchantSpriteSheet()
        {
            return merchantSpriteSheet;
        }

        public static Texture2D GetFireSpriteSheet()
        {
            return fireSpriteSheet;
        }

        public static Texture2D GetTrapSpriteSheet()
        {
            return trapSpriteSheet;
        }

        public static Texture2D GetNewTrapSpriteSheet()
        {
            return newtrapSpriteSheet;
        }

        public static Texture2D GetNewTrap1SpriteSheet()
        {
            return newtrap1SpriteSheet;
        }

        public static Texture2D GetAquamentuisBatProjectileSpriteSheet()
        {
            return aquamentusBatProjectileSheet;
        }

        public static Texture2D GetSawSpriteSheet()
        {
            return sawSpriteSheet;
        }

        public static Texture2D GetBurningSawSpriteSheet()
        {
            return burningSawSpriteSheet;
        }
           
        public static Texture2D GetFreezingSawSpriteSheet()
        {
            return freezingSawSpriteSheet;
        }

    }
}
