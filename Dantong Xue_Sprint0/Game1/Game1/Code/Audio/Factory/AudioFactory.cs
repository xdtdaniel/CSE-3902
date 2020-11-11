using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Game1.Code.Audio.Factory
{
	public static class AudioFactory
	{
		// BGM
		private static SoundEffect bgm;


		public static void LoadAllAudio(ContentManager content)
		{
			// BGM
			bgm = content.Load<SoundEffect>("Audio/MainTheme");
		}

		// BGM
		public static SoundEffect LoadBgm()
		{
			return bgm;
		}
	}
}
