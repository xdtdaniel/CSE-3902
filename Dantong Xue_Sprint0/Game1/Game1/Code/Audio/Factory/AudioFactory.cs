using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Game1.Code.Audio.Factory
{
	public static class AudioFactory
	{
		// BGM
		private static Song bgm;

		//SoundEffects
		private static SoundEffect getRupee;
		private static SoundEffect getItem;
		private static SoundEffect linkHurt;
		private static SoundEffect linkDead;
		public static void LoadAllAudio(ContentManager content)
		{
			// BGM
			bgm = content.Load<Song>("Audio/MainTheme");

			//SoundEffects
			getRupee = content.Load<SoundEffect>("Audio/Get_Rupee");
			getItem = content.Load<SoundEffect>("Audio/Get_Item");
			linkHurt = content.Load<SoundEffect>("Audio/Link_Hurt");
			linkDead = content.Load<SoundEffect>("Audio/Link_Die");
		}

		// BGM
		public static Song LoadBgm()
		{
			return bgm;
		}

		//SoundEffects

		public static SoundEffect LoadGetRupee()
		{
			return getRupee;
		}

		public static SoundEffect LoadGetItem()
		{
			return getItem;
		}

		public static SoundEffect LoadLinkHurt()
		{
			return linkHurt;
		}
		public static SoundEffect LoadLinkDead()
		{
			return linkDead;
		}
	}
}
