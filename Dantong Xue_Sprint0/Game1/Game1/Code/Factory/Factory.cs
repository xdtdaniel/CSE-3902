using Game1.Code.Item.ItemInterface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Item.ItemSprite;
using System;
using System.Collections.Generic;
using System.Text;
using Game1.Player;
using Microsoft.Xna.Framework;

namespace Game1.Code
{
	//factory is only used to generate the sprite, it return texture2D used by each item sprite class.
	public static class Factory
	{
		//Items
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

		//HUD factory
		private static Texture2D hudFrame;

		//Enemies
		private static Texture2D gelSpriteSheet;
		private static Texture2D keeseSpriteSheet;
		private static Texture2D stalfosSpriteSheet;
		private static Texture2D goriyaSpriteSheet;
		private static Texture2D goriyaProjectileSpriteSheet;
		private static Texture2D wallmasterSpriteSheet;
		private static Texture2D aquamentusSpriteSheet;
		private static Texture2D aquamentusProjectileSpriteSheet;
		private static Texture2D oldManSpriteSheet;
		private static Texture2D merchantSpriteSheet;
		private static Texture2D fireSpriteSheet;
		private static Texture2D trapSpriteSheet;






		public static void LoadAllTextures(ContentManager content)
		{
			//Items
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

			//HUD
			hudFrame = content.Load<Texture2D>("HUD/HUD_frame");

			//Enemies
			gelSpriteSheet = content.Load<Texture2D>("Sprite/enemies/gel_sprite");
			keeseSpriteSheet = content.Load<Texture2D>("Sprite/enemies/keese_sprite");
			stalfosSpriteSheet = content.Load<Texture2D>("Sprite/enemies/stalfos_sprite");
			goriyaSpriteSheet = content.Load<Texture2D>("Sprite/enemies/goriya_sprite");
			goriyaProjectileSpriteSheet = content.Load<Texture2D>("Sprite/enemies/goriya_projectile_sprite");
			wallmasterSpriteSheet = content.Load<Texture2D>("Sprite/enemies/wallmaster_sprite");
			aquamentusSpriteSheet = content.Load<Texture2D>("Sprite/enemies/aquamentus_sprite");
			aquamentusProjectileSpriteSheet = content.Load<Texture2D>("Sprite/enemies/aquamentus_projectile_sprite");
			oldManSpriteSheet = content.Load<Texture2D>("Sprite/npcs/oldman_sprite");
			merchantSpriteSheet = content.Load<Texture2D>("Sprite/npcs/merchant_sprite");
			fireSpriteSheet = content.Load<Texture2D>("Sprite/npcs/fire_sprite");
			trapSpriteSheet = content.Load<Texture2D>("Sprite/enemies/trap_sprite");


		}


		//Items
		public static Texture2D CreateArrow()
		{

			return arrow;
		}

		public static Texture2D CreateBomb()
		{
			return bomb;
		}
		public static Texture2D CreateBoomerang()
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
		public static Texture2D CreateHeartContainer()
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

		//HUD
		public static Texture2D LoadHUDFrame()
		{

			return hudFrame;
		}

		//Enemies
		public static Texture2D GetGelSpriteSheet()
		{
			return gelSpriteSheet;
		}

		public static Texture2D GetKeeseSpriteSheet()
		{
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

		public static Texture2D GetWallmasterSpriteSheet()
		{
			return wallmasterSpriteSheet;
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
	}
}
