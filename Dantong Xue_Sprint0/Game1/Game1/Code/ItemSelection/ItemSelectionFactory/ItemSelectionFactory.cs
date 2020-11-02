using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Game1.Player;
using Microsoft.Xna.Framework;
using Game1.Code.ItemSelection.ItemSelectionSprite;

namespace Game1.Code.ItemSelection.ItemSelectionFactory
{
	public static class ItemSelectionFactory
	{

		private static Texture2D ItemSelectionFrame_Top;
		private static Texture2D ItemSelectionFrame_Bottom;

		public static void LoadAllTextures(ContentManager content)
		{
			ItemSelectionFrame_Top = content.Load<Texture2D>("ItemSelection/Item_Selection_Top");
			ItemSelectionFrame_Bottom = content.Load<Texture2D>("ItemSelection/Item_Selection_Bottom");

		}

		public static Texture2D LoadItemSelectionFrame_Top()
		{
			return ItemSelectionFrame_Top;
		}
		public static Texture2D LoadItemSelectionFrame_Bottom()
		{
			return ItemSelectionFrame_Bottom;
		}

	}
}
