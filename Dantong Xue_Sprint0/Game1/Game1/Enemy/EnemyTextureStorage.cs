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
        private static Texture2D wallmasterSpriteSheet;
        private static Texture2D aquamentusSpriteSheet;
        private static Texture2D aquamentusProjectileSpriteSheet;

        public static void LoadTextures(ContentManager content) {
            gelSpriteSheet = content.Load<Texture2D>("Sprite/enemies/gel_sprite");
            keeseSpriteSheet = content.Load<Texture2D>("Sprite/enemies/keese_sprite");
            stalfosSpriteSheet = content.Load<Texture2D>("Sprite/enemies/stalfos_sprite");
            goriyaSpriteSheet = content.Load<Texture2D>("Sprite/enemies/goriya_sprite");
            goriyaProjectileSpriteSheet = content.Load<Texture2D>("Sprite/enemies/goriya_projectile_sprite");
            wallmasterSpriteSheet = content.Load<Texture2D>("Sprite/enemies/wallmaster_sprite");
            aquamentusSpriteSheet = content.Load<Texture2D>("Sprite/enemies/aquamentus_sprite");
            aquamentusProjectileSpriteSheet = content.Load<Texture2D>("Sprite/enemies/aquamentus_projectile_sprite");
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
    }
}
