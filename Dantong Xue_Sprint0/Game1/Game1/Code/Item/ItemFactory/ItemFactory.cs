using Game1.Code.Item.ItemInterface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Item.ItemSprite;
using System;
using System.Collections.Generic;
using System.Text;
using Game1.Player;

namespace Game1.Code.Item.ItemFactory
{
	public class ItemSpriteFactory
	{
		private Texture2D arrow;
		private Texture2D bomb;
		private Texture2D boomerang;
		private Texture2D bow;
		private Texture2D clock;
		private Texture2D compass;
		private Texture2D fairy;
		private Texture2D heart_container;
		private Texture2D heart;
		private Texture2D key;
		private Texture2D map;
		private Texture2D ruby;
		private Texture2D triforce;


		private static ItemSpriteFactory instance = new ItemSpriteFactory();

		public static ItemSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private ItemSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
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
		}

		public IItemSprite CreateArrow()
		{
			return new ItemSprite.Arrow(arrow);
		}

		public IItemSprite CreateBomb()
		{
			return new ItemSprite.Bomb(bomb);
		}
		public IItemSprite CreateBoomerang()
		{
			return new ItemSprite.Boomerang(boomerang);
		}
		public IItemSprite CreateBow()
		{
			return new ItemSprite.Bow(bow);
		}
		public IItemSprite CreateClock()
		{
			return new ItemSprite.Clock(clock);
		}
		public IItemSprite CreateCompass()
		{
			return new ItemSprite.Compass(compass);
		}
		public IItemSprite CreateFairy()
		{
			return new ItemSprite.Fairy(fairy);
		}
		//related to player current value of heart, Map HUD element
		public IItemSprite CreateHeartContainer()
		{
			return new ItemSprite.HeartContainer(heart_container);
		}
		public IItemSprite CreateHeart()
		{
			return new ItemSprite.Heart(heart);
		}
		public IItemSprite CreateKey()
		{
			return new ItemSprite.Key(key);
		}
		public IItemSprite CreateMap()
		{
			return new ItemSprite.Map(map);
		}
		public IItemSprite CreateRuby()
		{
			return new ItemSprite.Ruby(ruby);
		}
		public IItemSprite CreateTriforce()
		{
			return new ItemSprite.Triforce(triforce);
		}


	}
}
