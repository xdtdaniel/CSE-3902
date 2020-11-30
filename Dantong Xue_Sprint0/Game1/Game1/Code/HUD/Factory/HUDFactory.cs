using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.HUD.Factory
{
	public static class HUDFactory
	{
		// HUD
		private static Texture2D hudFrame;
		private static Texture2D inventoryFrame;
		private static Texture2D pause;
		private static Texture2D abilityTreeFrame;
		private static Texture2D abilityBar;
		private static SpriteFont font;

		// dungeon only
		private static Texture2D dungeonMiniMapCell_Level1;
		private static Texture2D dungeonMiniMapFrame;
		private static Texture2D dungeonPauseScreenFrame;
		private static Texture2D dungeonPauseScreenMapCell_Level1;

		// color spots
		private static Texture2D blackSpot;
		private static Texture2D blueSpot;
		private static Texture2D brownSpot;
		private static Texture2D emeraldSpot;
		private static Texture2D forestSpot;
		private static Texture2D graySpot;
		private static Texture2D greenSpot;
		private static Texture2D navySpot;
		private static Texture2D redSpot;
		private static Texture2D skySpot;
		private static Texture2D steelSpot;

		// symbols
		private static Texture2D zero;
		private static Texture2D one;
		private static Texture2D two;
		private static Texture2D three;
		private static Texture2D four;
		private static Texture2D five;
		private static Texture2D six;
		private static Texture2D seven;
		private static Texture2D eight;
		private static Texture2D nine;
		private static Texture2D A;
		private static Texture2D X;
		private static Texture2D emptyHeart;
		private static Texture2D halfHeart;
		private static Texture2D fullHeart;
		private static Texture2D firstEquipment;
		private static Texture2D secondEquipment;
		private static Texture2D inventorySelection;

		// indicators
		private static Texture2D emptyDashCharge;
		private static Texture2D fullDashCharge;
		private static Texture2D[] dashChargeGlitter;

		//experience pattern
		private static Texture2D exp;	

		public static void LoadAllHUDTextures(ContentManager content)
		{
			// HUD
			hudFrame = content.Load<Texture2D>("HUD/HUDFrame");
			inventoryFrame = content.Load<Texture2D>("HUD/InventoryFrame");
			pause = content.Load<Texture2D>("HUD/Pause");
			abilityTreeFrame = content.Load<Texture2D>("HUD/AbilityTreeFrame");
			abilityBar = content.Load<Texture2D>("HUD/AbilityBar");
			font = content.Load<SpriteFont>("font");

			// dungeon only
			dungeonMiniMapCell_Level1 = content.Load<Texture2D>("HUD/DungeonMiniMapCell_Level1");
			dungeonMiniMapFrame = content.Load<Texture2D>("HUD/DungeonMiniMapFrame");
			dungeonPauseScreenFrame = content.Load<Texture2D>("HUD/DungeonPauseScreenFrame");
			dungeonPauseScreenMapCell_Level1 = content.Load<Texture2D>("HUD/DungeonPauseScreenMapCell_Level1");

			// color spots
			blackSpot = content.Load<Texture2D>("HUD/ColorSpot/BlackSpot");
			blueSpot = content.Load<Texture2D>("HUD/ColorSpot/BlueSpot");
			brownSpot = content.Load<Texture2D>("HUD/ColorSpot/BrownSpot");
			emeraldSpot = content.Load<Texture2D>("HUD/ColorSpot/EmeraldSpot");
			forestSpot = content.Load<Texture2D>("HUD/ColorSpot/ForestSpot");
			graySpot = content.Load<Texture2D>("HUD/ColorSpot/GraySpot");
			greenSpot = content.Load<Texture2D>("HUD/ColorSpot/GreenSpot");
			navySpot = content.Load<Texture2D>("HUD/ColorSpot/NavySpot");
			redSpot = content.Load<Texture2D>("HUD/ColorSpot/RedSpot");
			skySpot = content.Load<Texture2D>("HUD/ColorSpot/SkySpot");
			steelSpot = content.Load<Texture2D>("HUD/ColorSpot/SteelSpot");

			//symbols
			zero = content.Load<Texture2D>("HUD/Misc/0");
			one = content.Load<Texture2D>("HUD/Misc/1");
			two = content.Load<Texture2D>("HUD/Misc/2");
			three = content.Load<Texture2D>("HUD/Misc/3");
			four = content.Load<Texture2D>("HUD/Misc/4");
			five = content.Load<Texture2D>("HUD/Misc/5");
			six = content.Load<Texture2D>("HUD/Misc/6");
			seven = content.Load<Texture2D>("HUD/Misc/7");
			eight = content.Load<Texture2D>("HUD/Misc/8");
			nine = content.Load<Texture2D>("HUD/Misc/9");
			A = content.Load<Texture2D>("HUD/Misc/A");
			X = content.Load<Texture2D>("HUD/Misc/X");
			emptyHeart = content.Load<Texture2D>("HUD/Misc/EmptyHeart");
			halfHeart = content.Load<Texture2D>("HUD/Misc/HalfHeart");
			fullHeart = content.Load<Texture2D>("HUD/Misc/FullHeart");
			firstEquipment = content.Load<Texture2D>("HUD/Misc/FirstEquipment");
			secondEquipment = content.Load<Texture2D>("HUD/Misc/SecondEquipment");
			inventorySelection = content.Load<Texture2D>("HUD/Misc/InventorySelection");

			//indicators
			emptyDashCharge = content.Load<Texture2D>("HUD/Indicator/EmptyDashCharge");
			fullDashCharge = content.Load<Texture2D>("HUD/Indicator/FullDashCharge");

			dashChargeGlitter = new Texture2D[3];
			dashChargeGlitter[0] = content.Load<Texture2D>("HUD/Indicator/DashChargeGlitter_0");
			dashChargeGlitter[1] = content.Load<Texture2D>("HUD/Indicator/DashChargeGlitter_1");
			dashChargeGlitter[2] = content.Load<Texture2D>("HUD/Indicator/DashChargeGlitter_2");

			//experience pattern
			exp = content.Load<Texture2D>("HUD/Others/expPattern");
			
		}

		// HUD
		public static Texture2D LoadHUDFrame()
		{
			return hudFrame;
		}
		public static Texture2D LoadInventoryFrame()
		{
			return inventoryFrame;
		}
		public static Texture2D LoadPause()
		{
			return pause;
		}
		public static Texture2D LoadAbilityTreeFrame()
		{
			return abilityTreeFrame;
		}
		public static Texture2D LoadAbilityBar()
		{
			return abilityBar;
		}
		public static SpriteFont LoadLevelUpText()
		{
			return font;
		}

		// dungeon only
		public static Texture2D LoadDungeonMiniMapCell_Level1()
		{
			return dungeonMiniMapCell_Level1;
		}
		public static Texture2D LoadDungeonMiniMapFrame()
		{
			return dungeonMiniMapFrame;
		}
		public static Texture2D LoadDungeonPauseScreenFrame()
		{
			return dungeonPauseScreenFrame;
		}
		public static Texture2D LoadDungeonPauseScreenMapCell_Level1()
		{
			return dungeonPauseScreenMapCell_Level1;
		}

		// color spots
		public static Texture2D LoadBlackSpot()
		{
			return blackSpot;
		}
		public static Texture2D LoadBlueSpot()
		{
			return blueSpot;
		}
		public static Texture2D LoadBrownSpot()
		{
			return brownSpot;
		}
		public static Texture2D LoadEmeraldSpot()
		{
			return emeraldSpot;
		}
		public static Texture2D LoadForestSpot()
		{
			return forestSpot;
		}
		public static Texture2D LoadGraySpot()
		{
			return graySpot;
		}
		public static Texture2D LoadGreenSpot()
		{
			return greenSpot;
		}
		public static Texture2D LoadNavySpot()
		{
			return navySpot;
		}
		public static Texture2D LoadRedSpot()
		{
			return redSpot;
		}
		public static Texture2D LoadSkySpot()
		{
			return skySpot;
		}
		public static Texture2D LoadSteelSpot()
		{
			return steelSpot;
		}

		// symbols
		public static Texture2D[] LoadNumber(int number)
		{
			int firstNumber = number / 10;
			int secondNumber = number % 10;
			if (number > 99) // no more than two digits
			{
				firstNumber = secondNumber = 9;
			}
			else if (number < 0) // no negative numbers
			{
				firstNumber = secondNumber = 0;
			}
			Texture2D[] numberTexture = new Texture2D[2];

			// 0 for first, 1 for second
			switch (firstNumber)
			{
				case 0:
					numberTexture[0] = zero;
					break;
				case 1:
					numberTexture[0] = one;
					break;
				case 2:
					numberTexture[0] = two;
					break;
				case 3:
					numberTexture[0] = three;
					break;
				case 4:
					numberTexture[0] = four;
					break;
				case 5:
					numberTexture[0] = five;
					break;
				case 6:
					numberTexture[0] = six;
					break;
				case 7:
					numberTexture[0] = seven;
					break;
				case 8:
					numberTexture[0] = eight;
					break;
				case 9:
					numberTexture[0] = nine;
					break;
				default:
					break;
			}
			switch (secondNumber)
			{
				case 0:
					numberTexture[1] = zero;
					break;
				case 1:
					numberTexture[1] = one;
					break;
				case 2:
					numberTexture[1] = two;
					break;
				case 3:
					numberTexture[1] = three;
					break;
				case 4:
					numberTexture[1] = four;
					break;
				case 5:
					numberTexture[1] = five;
					break;
				case 6:
					numberTexture[1] = six;
					break;
				case 7:
					numberTexture[1] = seven;
					break;
				case 8:
					numberTexture[1] = eight;
					break;
				case 9:
					numberTexture[1] = nine;
					break;
				default:
					break;
			}
			return numberTexture;
		}
		//heart should be 1 object
		public static Texture2D LoadEmptyHeart()
		{
			return emptyHeart;
		}
		public static Texture2D LoadHalfHeart()
		{
			return halfHeart;
		}
		public static Texture2D LoadFullHeart()
		{
			return fullHeart;
		}
		public static Texture2D LoadA()
		{
			return A;
		}
		public static Texture2D LoadX()
		{
			return X;
		}
		public static Texture2D LoadFirstEquipment()
		{
			return firstEquipment;
		}
		public static Texture2D LoadSecondEquipment()
		{
			return secondEquipment;
		}

		public static Texture2D LoadInventorySelection() {
			return inventorySelection;
		}

		// indicators
		public static Texture2D LoadEmptyDashChagre()
		{
			return emptyDashCharge;
		}
		public static Texture2D LoadFullDashCharge()
		{
			return fullDashCharge;
		}
		public static Texture2D[] LoadDashChargeGlitter()
		{
			return dashChargeGlitter;
		}

		//experience pattern 
		public static Texture2D LoadExpPattern()
		{
			return exp;
		}
	
	}
}
