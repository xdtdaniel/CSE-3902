using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Achievement.Factory
{
	public static class AchievementFactory
	{
		private static Texture2D marathonRunner;
		private static Texture2D undefeated;
		private static Texture2D dragonSlayer;
		private static Texture2D master;
		private static Texture2D pentaKill;
		private static Texture2D perfection;
		private static Texture2D stopRolling;
		private static Texture2D wealthy;
		private static Texture2D wrathOfTheDead;
		private static Texture2D trialAndError;
		public static void LoadAll(ContentManager content)
		{
			marathonRunner = content.Load<Texture2D>("Achievement/MarathonRunner");
			undefeated = content.Load<Texture2D>("Achievement/Undefeated");
			dragonSlayer = content.Load<Texture2D>("Achievement/DragonSlayer");
			master = content.Load<Texture2D>("Achievement/Master");
			pentaKill = content.Load<Texture2D>("Achievement/PentaKill");
			perfection = content.Load<Texture2D>("Achievement/Perfection");
			stopRolling = content.Load<Texture2D>("Achievement/StopRolling");
			wealthy = content.Load<Texture2D>("Achievement/Wealthy");
			wrathOfTheDead = content.Load<Texture2D>("Achievement/WrathOfTheDead");
			trialAndError = content.Load<Texture2D>("Achievement/TrialAndError");



		}

		public static Texture2D GetMarathonRunner()
		{
			return marathonRunner;
		}
		public static Texture2D GetUndefeated()
		{
			return undefeated;
		}
		public static Texture2D GetDragonSlayer()
		{
			return dragonSlayer;
		}
		public static Texture2D GetMaster()
		{
			return master;
		}
		public static Texture2D GetPentaKill()
		{
			return pentaKill;
		}
		public static Texture2D GetPerfection()
		{
			return perfection;
		}
		public static Texture2D GetStopRolling()
		{
			return stopRolling;
		}
		public static Texture2D GetWealthy()
		{
			return wealthy;
		}
		public static Texture2D GetWrathOfTheDead()
		{
			return wrathOfTheDead;
		}
		public static Texture2D GetTrialAndError()
		{
			return trialAndError;
		}

	}
}