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
        private Texture2D[] woodenSword;
        private Texture2D[] swordBeam;

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

        private Texture2D[] woodenEdge;
        private Texture2D[] beamEdge;

        public static PlayerItemFactory Instance { get; } = new PlayerItemFactory();

        private PlayerItemFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            woodenSword = new Texture2D[4];
            woodenSword[0] = content.Load<Texture2D>("PlayerItemSprite/Weapon/WoodenSword0");
            woodenSword[1] = content.Load<Texture2D>("PlayerItemSprite/Weapon/WoodenSword1");
            woodenSword[2] = content.Load<Texture2D>("PlayerItemSprite/Weapon/WoodenSword2");
            woodenSword[3] = content.Load<Texture2D>("PlayerItemSprite/Weapon/WoodenSword3");

            swordBeam = new Texture2D[4];
            swordBeam[0] = content.Load<Texture2D>("PlayerItemSprite/Weapon/SwordBeam0");
            swordBeam[1] = content.Load<Texture2D>("PlayerItemSprite/Weapon/SwordBeam1");
            swordBeam[2] = content.Load<Texture2D>("PlayerItemSprite/Weapon/SwordBeam2");
            swordBeam[3] = content.Load<Texture2D>("PlayerItemSprite/Weapon/SwordBeam3");

            frontArrow = content.Load<Texture2D>("PlayerItemSprite/Arrow/FrontArrow");
            rightArrow = content.Load<Texture2D>("PlayerItemSprite/Arrow/RightArrow");
            backArrow = content.Load<Texture2D>("PlayerItemSprite/Arrow/BackArrow");
            leftArrow = content.Load<Texture2D>("PlayerItemSprite/Arrow/LeftArrow");

            frontBoomerang = content.Load<Texture2D>("PlayerItemSprite/Boomerang/FrontBoomerang");
            rightBoomerang = content.Load<Texture2D>("PlayerItemSprite/Boomerang/RightBoomerang");
            backBoomerang = content.Load<Texture2D>("PlayerItemSprite/Boomerang/BackBoomerang");
            leftBoomerang = content.Load<Texture2D>("PlayerItemSprite/Boomerang/LeftBoomerang");

            bomb = content.Load<Texture2D>("PlayerItemSprite/Bomb/Bomb");
            bombExplosion = content.Load<Texture2D>("PlayerItemSprite/Bomb/BombExplosion");

            blueCandle = content.Load<Texture2D>("PlayerItemSprite/Candle/BlueCandle");

            bluePotion = content.Load<Texture2D>("PlayerItemSprite/Potion/BluePotion");

            blueRing = content.Load<Texture2D>("PlayerItemSprite/Ring/BlueRing");

            woodenEdge = new Texture2D[4];
            woodenEdge[0] = content.Load<Texture2D>("PlayerItemSprite/Edge/WoodenEdge0");
            woodenEdge[1] = content.Load<Texture2D>("PlayerItemSprite/Edge/WoodenEdge1");
            woodenEdge[2] = content.Load<Texture2D>("PlayerItemSprite/Edge/WoodenEdge2");
            woodenEdge[3] = content.Load<Texture2D>("PlayerItemSprite/Edge/WoodenEdge3");

            beamEdge = new Texture2D[4];
            beamEdge[0] = content.Load<Texture2D>("PlayerItemSprite/Edge/beamEdge0");
            beamEdge[1] = content.Load<Texture2D>("PlayerItemSprite/Edge/beamEdge1");
            beamEdge[2] = content.Load<Texture2D>("PlayerItemSprite/Edge/beamEdge2");
            beamEdge[3] = content.Load<Texture2D>("PlayerItemSprite/Edge/beamEdge3");
        }

        /* sword */
        public IPlayerItemSprite CreateWoodenSword(int index)
        {
            return new WoodenSword(woodenSword[index]);
        }
        public IPlayerItemSprite CreateSwordBeam(int index)
        {
            return new SwordBeam(swordBeam[index]);
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

        public IPlayerItemSprite CreateWoodenEdge(int index)
        {
            return new WoodenEdge(woodenEdge[index]);
        }
        public IPlayerItemSprite CreateBeamEdge(int index)
        {
            return new BeamEdge(beamEdge[index]);
        }
    }
}
