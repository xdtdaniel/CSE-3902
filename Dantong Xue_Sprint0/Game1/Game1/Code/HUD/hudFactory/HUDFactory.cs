using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.Item.ItemSprite;
using System;
using System.Collections.Generic;
using System.Text;
using Game1.Player;
using Microsoft.Xna.Framework;
namespace Game1.Code.HUD.hudFactory
{
	public static class HUDFactory
	{

		private static Texture2D hudFrame;

		public static void LoadAllHUDTextures(ContentManager content)
		{			
			hudFrame = content.Load<Texture2D>("HUD/HUD_frame");

		}


		public static Texture2D LoadHUDFrame()
		{

			return hudFrame;
		}

	}
}
