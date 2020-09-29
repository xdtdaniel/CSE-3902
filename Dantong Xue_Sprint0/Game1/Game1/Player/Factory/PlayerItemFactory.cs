using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player;

namespace Game1
{
    class PlayerItemFactory
    {
        private Texture2D woodenSword;
        private Texture2D swordBeam;

        private Texture2D frontArrow;
        private Texture2D rightArrow;
        private Texture2D backArrow;
        private Texture2D leftArrow;

        private Texture2D frontBoomerang;
        private Texture2D rightBoomerang;
        private Texture2D backBoomerang;
        private Texture2D leftBoomerang;

        private Texture2D bomb;
        private Texture2D bombExplosion;

        private Texture2D blueCandle;
        private Texture2D bluePotion;
        private Texture2D blueRing;

        private static PlayerItemFactory instance = new PlayerItemFactory();

        public static PlayerItemFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PlayerItemFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            woodenSword = content.Load<Texture2D>("PlayerItemSprite/WoodenSword");
            swordBeam = content.Load<Texture2D>("PlayerItemSprite/SwordBeam");

            frontArrow = content.Load<Texture2D>("PlayerItemSprite/FrontArrow");
            rightArrow = content.Load<Texture2D>("PlayerItemSprite/RightArrow");
            backArrow = content.Load<Texture2D>("PlayerItemSprite/BackArrow");
            leftArrow = content.Load<Texture2D>("PlayerItemSprite/LeftArrow");

            frontBoomerang = content.Load<Texture2D>("PlayerItemSprite/FrontBoomerang");
            rightBoomerang = content.Load<Texture2D>("PlayerItemSprite/RightBoomerang");
            backBoomerang = content.Load<Texture2D>("PlayerItemSprite/BackBoomerang");
            leftBoomerang = content.Load<Texture2D>("PlayerItemSprite/LeftBoomerang");

            bomb = content.Load<Texture2D>("PlayerItemSprite/Bomb");
            bombExplosion = content.Load<Texture2D>("PlayerItemSprite/BombExplosion");

            blueCandle = content.Load<Texture2D>("PlayerItemSprite/BlueCandle");
            bluePotion = content.Load<Texture2D>("PlayerItemSprite/BluePotion");
            blueRing = content.Load<Texture2D>("PlayerItemSprite/BlueRing");
        }

        /* sword */
        public IPlayerSprite CreateWoordenSword()
        {
            return new WoodenSword(woodenSword);
        }
        public IPlayerSprite CreateSwordBeam()
        {
            return new SwordBeam(swordBeam);
        }

        /* arrow */
        public IPlayerSprite CreateFrontArrow()
        {
            return new Arrow(frontArrow);
        }
        public IPlayerSprite CreateRightArrow()
        {
            return new Arrow(rightArrow);
        }
        public IPlayerSprite CreateBackArrow()
        {
            return new Arrow(backArrow);
        }
        public IPlayerSprite CreateLeftArrow()
        {
            return new Arrow(leftArrow);
        }

        /* boomerang */
        public IPlayerSprite CreateFrontBoomerang()
        {
            return new Boomerang(frontBoomerang);
        }
        public IPlayerSprite CreateRightBoomerang()
        {
            return new Boomerang(rightBoomerang);
        }
        public IPlayerSprite CreateBackBoomerang()
        {
            return new Boomerang(backBoomerang);
        }
        public IPlayerSprite CreateLeftBoomerang()
        {
            return new Boomerang(leftBoomerang);
        }

        /* bomb */
        public IPlayerSprite CreateBomb()
        {
            return new Bomb(bomb);
        }
        public IPlayerSprite CreateBombExplosion()
        {
            return new BombExplosion(bombExplosion);
        }

        public IPlayerSprite CreateBlueCandle()
        {
            return new BlueCandle(blueCandle);
        }
        public IPlayerSprite CreateBluePotion()
        {
            return new BluePotion(bluePotion);
        }
        public IPlayerSprite CreateBlueRing()
        {
            return new BlueRing(blueRing);
        }

    }
}
