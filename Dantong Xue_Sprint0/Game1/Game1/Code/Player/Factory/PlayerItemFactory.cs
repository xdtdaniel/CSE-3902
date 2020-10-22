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
using Game1.Code.Player.PlayerItem.PlayerItemSprite;

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

        private Texture2D woodenSwordAttack;
        private Texture2D swordBeamAttack;


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

            // not used
            woodenSwordAttack = content.Load<Texture2D>("PlayerItemSprite/WoodenSwordAttack");
            swordBeamAttack = content.Load<Texture2D>("PlayerItemSprite/SwordBeamAttack");
        }

        /* sword */
        public IPlayerItemSprite CreateWoordenSword()
        {
            return new WoodenSword(woodenSword);
        }
        public IPlayerItemSprite CreateSwordBeam()
        {
            return new SwordBeam(swordBeam);
        }

        /* arrow */
        public IPlayerItemSprite CreateFrontArrow()
        {
            return new Arrow(frontArrow);
        }
        public IPlayerItemSprite CreateRightArrow()
        {
            return new Arrow(rightArrow);
        }
        public IPlayerItemSprite CreateBackArrow()
        {
            return new Arrow(backArrow);
        }
        public IPlayerItemSprite CreateLeftArrow()
        {
            return new Arrow(leftArrow);
        }

        /* boomerang */
        public IPlayerItemSprite CreateFrontBoomerang()
        {
            return new Boomerang(frontBoomerang);
        }
        public IPlayerItemSprite CreateRightBoomerang()
        {
            return new Boomerang(rightBoomerang);
        }
        public IPlayerItemSprite CreateBackBoomerang()
        {
            return new Boomerang(backBoomerang);
        }
        public IPlayerItemSprite CreateLeftBoomerang()
        {
            return new Boomerang(leftBoomerang);
        }

        /* bomb */
        public IPlayerItemSprite CreateBomb()
        {
            return new Bomb(bomb);
        }
        public IPlayerItemSprite CreateBombExplosion()
        {
            return new BombExplosion(bombExplosion);
        }

        public IPlayerItemSprite CreateBlueCandle()
        {
            return new BlueCandle(blueCandle);
        }
        public IPlayerItemSprite CreateBluePotion()
        {
            return new BluePotion(bluePotion);
        }
        public IPlayerItemSprite CreateBlueRing()
        {
            return new BlueRing(blueRing);
        }

    }
}
