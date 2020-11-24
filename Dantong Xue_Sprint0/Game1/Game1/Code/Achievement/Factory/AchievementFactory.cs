using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Achievement.Factory
{
	public static class AchievementFactory
	{
		private static Texture2D marathonRunner;
		private static Texture2D undefeated;
		public static void LoadAll(ContentManager content)
		{
			marathonRunner = content.Load<Texture2D>("Achievement/MarathonRunner");
			undefeated = content.Load<Texture2D>("Achievement/Undefeated");



		}

		public static Texture2D GetMarathonRunner()
		{
			return marathonRunner;
		}
		public static Texture2D GetUndefeated()
		{
			return undefeated;
		}

	}
}