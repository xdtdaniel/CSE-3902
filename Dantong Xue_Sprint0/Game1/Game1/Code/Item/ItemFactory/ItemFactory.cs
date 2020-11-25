using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Item.ItemFactory
{
	//factory is only used to generate the sprite, it return texture2D used by each item sprite class.
	public static class ItemSpriteFactory
	{
		private static Texture2D arrow;
		private static Texture2D bomb;
		private static Texture2D boomerang;
		private static Texture2D bow;
		private static Texture2D clock;
		private static Texture2D compass;
		private static Texture2D fairy;
		private static Texture2D heart_container;
		private static Texture2D heart;
		private static Texture2D key;
		private static Texture2D map;
		private static Texture2D ruby;
		private static Texture2D triforce;
		private static Texture2D woodenSword;
		private static Texture2D swordBeam;
		private static Texture2D blueCandle;
		private static Texture2D bluePotion;
		private static Texture2D blueRing;

		public static void LoadAllTextures(ContentManager content)
		{
			arrow = content.Load<Texture2D>("Sprite/items/arrow_sprite");
			bomb = content.Load<Texture2D>("Sprite/items/bomb_sprite");
			boomerang = content.Load<Texture2D>("Sprite/items/boomerang_sprite");
			bow = content.Load<Texture2D>("Sprite/items/bow_sprite");
			clock = content.Load<Texture2D>("Sprite/items/clock_sprite");
			compass = content.Load<Texture2D>("Sprite/items/compass_sprite");
			fairy = content.Load<Texture2D>("Sprite/items/fairy_sprite (8x16 for each)");
			heart_container = content.Load<Texture2D>("Sprite/items/heart_container_sprite");
			heart = content.Load<Texture2D>("Sprite/items/heart_sprite (7x8 for each)");
			key = content.Load<Texture2D>("Sprite/items/key_sprite");
			map = content.Load<Texture2D>("Sprite/items/map_sprite");
			ruby = content.Load<Texture2D>("Sprite/items/rubee_sprite (8x16 for each)");
			triforce = content.Load<Texture2D>("Sprite/items/triforce_sprite (10x10 for each)");
			woodenSword = content.Load<Texture2D>("PlayerItemSprite/Weapon/WoodenSword0");
			swordBeam = content.Load<Texture2D>("PlayerItemSprite/Weapon/SwordBeam0");
			blueCandle = content.Load<Texture2D>("PlayerItemSprite/Candle/BlueCandle");
			bluePotion = content.Load<Texture2D>("PlayerItemSprite/Potion/BluePotion");
			blueRing = content.Load<Texture2D>("PlayerItemSprite/Ring/BlueRing");
		}
	

		public static Texture2D CreateArrow()
		{

			return arrow;
		}

		public static Texture2D CreateBomb()
		{
			return bomb;
		}
		public static  Texture2D CreateBoomerang()
		{
			return boomerang;
		}
		public static Texture2D CreateBow()
		{
			return bow;
		}
		public static Texture2D CreateClock()
		{
			return clock;
		}
		public static Texture2D CreateCompass()
		{
			return compass;
		}
		public static Texture2D CreateFairy()
		{
			return fairy;
		}
		public static  Texture2D CreateHeartContainer()
		{
			return heart_container;
		}
		public static Texture2D CreateHeart()
		{
			return heart;
		}
		public static Texture2D CreateKey()
		{
			return key;
		}
		public static Texture2D CreateMap()
		{
			return map;
		}
		public static Texture2D CreateRuby()
		{
			return ruby;
		}
		public static Texture2D CreateTriforce()
		{
			return triforce;
		}

		public static Texture2D CreateWoodenSword()
		{
			return woodenSword;
		}
		public static Texture2D CreateSwordBeam()
		{
			return swordBeam;
		}
		public static Texture2D CreateBlueCandle()
		{
			return blueCandle;
		}
		public static Texture2D CreateBluePotion()
		{
			return bluePotion;
		}
		public static Texture2D CreateBlueRing()
		{
			return blueRing;
		}

	}
}
