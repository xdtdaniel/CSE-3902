using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter.LinkSprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Player.Factory
{
    class PlayerCharacterFactory
    {
        private Texture2D[] normalLink;

        private Texture2D[] swordBeamLink;

        private Texture2D[] woodenSwordLink;

        private Texture2D[] useItemLink;

        private Texture2D pickUpLink;

        private Texture2D[][] damagedLink;

        private Texture2D[][] damagedSwordBeamLink;

        private Texture2D[][] damagedWoodenSwordLink;

        private Texture2D[][] damagedUseItemLink;

        private Texture2D[] damagedPickUpLink;

        public static PlayerCharacterFactory Instance { get; } = new PlayerCharacterFactory();

        private PlayerCharacterFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        { 
            // Normal Link 
            normalLink = new Texture2D[4];
            normalLink[0] = content.Load<Texture2D>("PlayerCharacterSprite/FrontLink");
            normalLink[1] = content.Load<Texture2D>("PlayerCharacterSprite/RightLink");
            normalLink[2] = content.Load<Texture2D>("PlayerCharacterSprite/BackLink");
            normalLink[3] = content.Load<Texture2D>("PlayerCharacterSprite/LeftLink");

            // Link with SwordBeam 
            swordBeamLink = new Texture2D[4];
            swordBeamLink[0] = content.Load<Texture2D>("PlayerCharacterSprite/FrontSwordBeam");
            swordBeamLink[1] = content.Load<Texture2D>("PlayerCharacterSprite/RightSwordBeam");
            swordBeamLink[2] = content.Load<Texture2D>("PlayerCharacterSprite/BackSwordBeam");
            swordBeamLink[3] = content.Load<Texture2D>("PlayerCharacterSprite/LeftSwordBeam");

            // Link with WoodenSword
            woodenSwordLink = new Texture2D[4];
            woodenSwordLink[0] = content.Load<Texture2D>("PlayerCharacterSprite/FrontWoodenSword");
            woodenSwordLink[1] = content.Load<Texture2D>("PlayerCharacterSprite/RightWoodenSword");
            woodenSwordLink[2] = content.Load<Texture2D>("PlayerCharacterSprite/BackWoodenSword");
            woodenSwordLink[3] = content.Load<Texture2D>("PlayerCharacterSprite/LeftWoodenSword");

            // Link UseItem
            useItemLink = new Texture2D[4];
            useItemLink[0] = content.Load<Texture2D>("PlayerCharacterSprite/FrontUseItem");
            useItemLink[1] = content.Load<Texture2D>("PlayerCharacterSprite/RightUseItem");
            useItemLink[2] = content.Load<Texture2D>("PlayerCharacterSprite/BackUseItem");
            useItemLink[3] = content.Load<Texture2D>("PlayerCharacterSprite/LeftUseItem");

            // Link PickUp
            pickUpLink = content.Load<Texture2D>("PlayerCharacterSprite/PickUp");

            // damaged Link 
            damagedLink = new Texture2D[4][];
            damagedLink[0] = new Texture2D[4];
            damagedLink[0][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_FrontLink");
            damagedLink[0][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_FrontLink");
            damagedLink[0][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_FrontLink");
            damagedLink[0][3] = normalLink[0];

            damagedLink[1] = new Texture2D[4];
            damagedLink[1][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_RightLink");
            damagedLink[1][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_RightLink");
            damagedLink[1][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_RightLink");
            damagedLink[1][3] = normalLink[1];

            damagedLink[2] = new Texture2D[4];
            damagedLink[2][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_BackLink");
            damagedLink[2][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_BackLink");
            damagedLink[2][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_BackLink");
            damagedLink[2][3] = normalLink[2];

            damagedLink[3] = new Texture2D[4];
            damagedLink[3][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_LeftLink");
            damagedLink[3][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_LeftLink");
            damagedLink[3][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_LeftLink");
            damagedLink[3][3] = normalLink[3];

            // damaged Link with SwordBeam
            damagedSwordBeamLink = new Texture2D[4][];
            damagedSwordBeamLink[0] = new Texture2D[4];
            damagedSwordBeamLink[0][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_FrontSwordBeam");
            damagedSwordBeamLink[0][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_FrontSwordBeam");
            damagedSwordBeamLink[0][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_FrontSwordBeam");
            damagedSwordBeamLink[0][3] = swordBeamLink[0];

            damagedSwordBeamLink[1] = new Texture2D[4];
            damagedSwordBeamLink[1][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_RightSwordBeam");
            damagedSwordBeamLink[1][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_RightSwordBeam");
            damagedSwordBeamLink[1][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_RightSwordBeam");
            damagedSwordBeamLink[1][3] = swordBeamLink[1];

            damagedSwordBeamLink[2] = new Texture2D[4];
            damagedSwordBeamLink[2][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_BackSwordBeam");
            damagedSwordBeamLink[2][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_BackSwordBeam");
            damagedSwordBeamLink[2][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_BackSwordBeam");
            damagedSwordBeamLink[2][3] = swordBeamLink[2];

            damagedSwordBeamLink[3] = new Texture2D[4];
            damagedSwordBeamLink[3][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_LeftSwordBeam");
            damagedSwordBeamLink[3][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_LeftSwordBeam");
            damagedSwordBeamLink[3][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_LeftSwordBeam");
            damagedSwordBeamLink[3][3] = swordBeamLink[3];

            // damaged Link with WoodenSword
            damagedWoodenSwordLink = new Texture2D[4][];
            damagedWoodenSwordLink[0] = new Texture2D[4];
            damagedWoodenSwordLink[0][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_FrontWoodenSword");
            damagedWoodenSwordLink[0][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_FrontWoodenSword");
            damagedWoodenSwordLink[0][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_FrontWoodenSword");
            damagedWoodenSwordLink[0][3] = woodenSwordLink[0];

            damagedWoodenSwordLink[1] = new Texture2D[4];
            damagedWoodenSwordLink[1][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_RightWoodenSword");
            damagedWoodenSwordLink[1][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_RightWoodenSword");
            damagedWoodenSwordLink[1][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_RightWoodenSword");
            damagedWoodenSwordLink[1][3] = woodenSwordLink[1];

            damagedWoodenSwordLink[2] = new Texture2D[4];
            damagedWoodenSwordLink[2][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_BackWoodenSword");
            damagedWoodenSwordLink[2][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_BackWoodenSword");
            damagedWoodenSwordLink[2][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_BackWoodenSword");
            damagedWoodenSwordLink[2][3] = woodenSwordLink[2];

            damagedWoodenSwordLink[3] = new Texture2D[4];
            damagedWoodenSwordLink[3][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_LeftWoodenSword");
            damagedWoodenSwordLink[3][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_LeftWoodenSword");
            damagedWoodenSwordLink[3][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_LeftWoodenSword");
            damagedWoodenSwordLink[3][3] = woodenSwordLink[3];

            // damaged Link UseItem
            damagedUseItemLink = new Texture2D[4][];
            damagedUseItemLink[0] = new Texture2D[4];
            damagedUseItemLink[0][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_FrontUseItem");
            damagedUseItemLink[0][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_FrontUseItem");
            damagedUseItemLink[0][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_FrontUseItem");
            damagedUseItemLink[0][3] = useItemLink[0];

            damagedUseItemLink[1] = new Texture2D[4];
            damagedUseItemLink[1][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_RightUseItem");
            damagedUseItemLink[1][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_RightUseItem");
            damagedUseItemLink[1][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_RightUseItem");
            damagedUseItemLink[1][3] = useItemLink[1];

            damagedUseItemLink[2] = new Texture2D[4];
            damagedUseItemLink[2][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_BackUseItem");
            damagedUseItemLink[2][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_BackUseItem");
            damagedUseItemLink[2][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_BackUseItem");
            damagedUseItemLink[2][3] = useItemLink[2];

            damagedUseItemLink[3] = new Texture2D[4];
            damagedUseItemLink[3][0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_LeftUseItem");
            damagedUseItemLink[3][1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_LeftUseItem");
            damagedUseItemLink[3][2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_LeftUseItem");
            damagedUseItemLink[3][3] = useItemLink[3];

            // damaged Link PickUp
            damagedPickUpLink = new Texture2D[4];
            damagedPickUpLink[0] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_1_PickUp");
            damagedPickUpLink[1] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_2_PickUp");
            damagedPickUpLink[2] = content.Load<Texture2D>("PlayerCharacterSprite/Damaged_3_PickUp");
            damagedPickUpLink[3] = pickUpLink;
        }

        // normal Link 
        public IPlayerLinkSprite CreateNormalLink(int index)
        {
            return new NormalLinkSprite(normalLink[index]);
        }

        public IPlayerLinkSprite CreateDashLink(int index)
        {
            return new DashLinkSprite(normalLink[index]);
        }
        // Link with SwordBeam 
        public IPlayerLinkSprite CreateSwordBeamLink(int index)
        {
            return new SwordLinkSprite(swordBeamLink[index]);
        }

        // Link with WoodenSword 
        public IPlayerLinkSprite CreateWoodenSwordLink(int index)
        {
            return new SwordLinkSprite(woodenSwordLink[index]);
        }

        // Link UseItem 
        public IPlayerLinkSprite CreateUseItemLink(int index)
        {
            return new UseItemLinkSprite(useItemLink[index]);
        }

        // Link PickUp
        public IPlayerLinkSprite CreatePickUpLink()
        {
            return new PickUpLinkSprite(pickUpLink);
        }

        // damaged link 
        public IPlayerLinkSprite[] CreateDamagedLink(int index)
        {
            IPlayerLinkSprite[] spriteArray = new IPlayerLinkSprite[4];
            for (int i = 0; i < 4; i++)
            {
                spriteArray[i] = new NormalLinkSprite(damagedLink[index][i]);
            }

            return spriteArray;
        }

        public IPlayerLinkSprite[] CreateDamagedSwordBeamLink(int index)
        {
            IPlayerLinkSprite[] spriteArray = new IPlayerLinkSprite[4];
            for (int i = 0; i < 4; i++)
            {
                spriteArray[i] = new SwordLinkSprite(damagedSwordBeamLink[index][i]);
            }

            return spriteArray;
        }

        public IPlayerLinkSprite[] CreateDamagedWoodenSwordLink(int index)
        {
            IPlayerLinkSprite[] spriteArray = new IPlayerLinkSprite[4];
            for (int i = 0; i < 4; i++)
            {
                spriteArray[i] = new SwordLinkSprite(damagedWoodenSwordLink[index][i]);
            }

            return spriteArray;
        }
        public IPlayerLinkSprite[] CreateDamagedUseItemLink(int index)
        {
            IPlayerLinkSprite[] spriteArray = new IPlayerLinkSprite[4];
            for (int i = 0; i < 4; i++)
            {
                spriteArray[i] = new UseItemLinkSprite(damagedUseItemLink[index][i]);
            }

            return spriteArray;
        }
        public IPlayerLinkSprite[] CreateDamagedPickUpLink()
        {
            IPlayerLinkSprite[] spriteArray = new IPlayerLinkSprite[4];
            for (int i = 0; i < 4; i++)
            {
                spriteArray[i] = new PickUpLinkSprite(damagedPickUpLink[i]);
            }
            return spriteArray;
        }
    }
}
