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
		private static SoundEffect getTriforce;
		private static SoundEffect linkHurt;
		private static SoundEffect linkDead;
		private static SoundEffect getHeart;
		private static SoundEffect bombBlow;
		private static SoundEffect bombDrop;
		private static SoundEffect swordSlash;
		private static SoundEffect swordShoot;
		private static SoundEffect doorUnlock;
		private static SoundEffect enemyHit;
		private static SoundEffect bossHit;
		private static SoundEffect enemyDie;
		private static SoundEffect linkLowHealth;
		private static SoundEffect arrowShoot;
		private static SoundEffect bossScream;
		public static void LoadAllAudio(ContentManager content)
		{
			// BGM
			bgm = content.Load<Song>("Audio/MainTheme");

			//SoundEffects
			//implemented
			getRupee = content.Load<SoundEffect>("Audio/Get_Rupee");
			getItem = content.Load<SoundEffect>("Audio/Get_Item");
			linkHurt = content.Load<SoundEffect>("Audio/Link_Hurt");
			linkDead = content.Load<SoundEffect>("Audio/Link_Die");
			getHeart = content.Load<SoundEffect>("Audio/Get_Heart"); //or key
			getTriforce = content.Load<SoundEffect>("Audio/Get_Triforce");
			bossHit = content.Load<SoundEffect>("Audio/Boss_Hit");
			bombBlow = content.Load<SoundEffect>("Audio/Bomb_Blow");
			bombDrop = content.Load<SoundEffect>("Audio/Bomb_Drop");
			swordSlash = content.Load<SoundEffect>("Audio/Sword_Slash");
			swordShoot = content.Load<SoundEffect>("Audio/Sword_Shoot");
			doorUnlock = content.Load<SoundEffect>("Audio/Door_Unlock");
			enemyHit = content.Load<SoundEffect>("Audio/Enemy_Hit");
			enemyDie = content.Load<SoundEffect>("Audio/Enemy_Die");
			linkLowHealth = content.Load<SoundEffect>("Audio/LowHealth");
			arrowShoot = content.Load<SoundEffect>("Audio/Arrow_Boomerang");
			bossScream = content.Load<SoundEffect>("Audio/Boss_Scream1");



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

		public static SoundEffect LoadGetHeart()
		{
			return getHeart;
		}
		public static SoundEffect LoadGetTriforce()
		{
			return getTriforce;
		}

		public static SoundEffect LoadLinkHurt()
		{
			return linkHurt;
		}
		public static SoundEffect LoadLinkDead()
		{
			return linkDead;
		}
		public static SoundEffect LoadBombBlow()
		{
			return bombBlow;
		}

		public static SoundEffect LoadBombDrop()
		{
			return bombDrop;
		}
		public static SoundEffect LoadSwordSlash()
		{
			return swordSlash;
		}

		public static SoundEffect LoadSwordShoot()
		{
			return swordShoot;
		}
		public static SoundEffect LoadDoorUnlock()
		{
			return doorUnlock;
		}

		public static SoundEffect LoadEnemyHit()
		{
			return enemyHit;
		}
		public static SoundEffect LoadBossHit()
		{
			return bossHit;
		}
		public static SoundEffect LoadEnemyDie()
		{
			return enemyDie;
		}

		public static SoundEffect LoadLinkLowHealth()
		{
			return linkLowHealth;
		}

		public static SoundEffect LoadArrowShoot()
		{
			return arrowShoot;
		}

		public static SoundEffect LoadBossScream()
		{
			return bossScream;
		}
	}
}
