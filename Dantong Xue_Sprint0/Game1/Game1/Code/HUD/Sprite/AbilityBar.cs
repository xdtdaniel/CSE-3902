using Game1.Code.HUD.Factory;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Game1.Code.Player.Control;
using Game1.Code.Player.PlayerAbility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Game1.Code.HUD.Sprite
{
    class AbilityBar : IHUDSprite
    {
        private static int scale = (int)LoadAll.Instance.scale;
        private int barWidth = 130 * scale;
        private int barHeight = 15 * scale;
        private int bar_x;
        private int bar_y;
        private int bar_preY = 161 * scale;

        private int iconWidth = 13 * scale;
        private int iconHeight = 12 * scale;
        private int icon_x;
        private int icon_y;
        private int icon_offset_x;
        private int cd_offset_x_UnitDigit = 1 * scale;
        private int cd_offset_x_TenDigits = 3 * scale;
        private int iconSpacing = 13 * scale;

        private Texture2D abilityTreeFrameTexture;
        private Texture2D blackSpot;
        private Dictionary<int, Texture2D> swordAbilityDict = new Dictionary<int, Texture2D>();
        private Dictionary<int, Texture2D> bowAbilityDict = new Dictionary<int, Texture2D>();
        public List<Dictionary<int, Texture2D>> abilityDictList = new List<Dictionary<int, Texture2D>>();

        private PlayerAbilityPanel pap;

        private Game1 game;
        public AbilityBar(Game1 game, PlayerAbilityPanel playerAbilityPanel)
        {
            this.game = game;

            abilityTreeFrameTexture = HUDFactory.LoadAbilityBar();
            blackSpot = HUDFactory.LoadBlackSpot();
            this.pap = playerAbilityPanel;

            swordAbilityDict.Add(0, HUDFactory.LoadBladeBarrage());
            swordAbilityDict.Add(1, HUDFactory.LoadDeadlySlash());
            swordAbilityDict.Add(2, HUDFactory.LoadLineImpact());
            swordAbilityDict.Add(3, HUDFactory.LoadFieldBlast());

            bowAbilityDict.Add(0, HUDFactory.LoadPiercingArrow());
            bowAbilityDict.Add(1, HUDFactory.LoadSplitArrow());
            bowAbilityDict.Add(2, HUDFactory.LoadQuickShot());
            bowAbilityDict.Add(3, HUDFactory.LoadEmpoweredShot());

            abilityDictList.Add(swordAbilityDict);
            abilityDictList.Add(bowAbilityDict);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, abilityTreeFrameTexture.Width, abilityTreeFrameTexture.Height);
            Rectangle destinationRectangle = new Rectangle(bar_x, bar_y, barWidth, barHeight);  

            spriteBatch.Draw(abilityTreeFrameTexture, destinationRectangle, sourceRectangle, Color.White);

            for (int i = 0; i < pap.registeredAbilities.Count; i++)
            {
                icon_offset_x = i * iconSpacing;
                int type = pap.registeredAbilities[i].Item1;
                int index = pap.registeredAbilities[i].Item2;
                Texture2D icon = abilityDictList[type][index];
                sourceRectangle = new Rectangle(0, 0, icon.Width, icon.Height);
                destinationRectangle = new Rectangle(icon_x + icon_offset_x, icon_y, iconWidth, iconHeight);

                spriteBatch.Draw(icon, destinationRectangle, sourceRectangle, Color.White);

                float percentage = pap.abilityDictList[type][index].GetCooldownPercentage();
                if (percentage < 1) // 1 means the ability is ready
                {
                    sourceRectangle = new Rectangle(0, 0, blackSpot.Width, blackSpot.Height);
                    destinationRectangle = new Rectangle(icon_x + icon_offset_x, icon_y, iconWidth, (int)(iconHeight * (1 - percentage)));

                    spriteBatch.Draw(blackSpot, destinationRectangle, sourceRectangle, Color.White * 0.8f);

                    int cd = (int)(pap.abilityDictList[type][index].GetRemainingCooldown() / 60) + 1; // 60 frames per second
                    int offset = cd_offset_x_UnitDigit;
                    if (cd < 10)
                    {
                        offset = cd_offset_x_TenDigits;
                    }
                    spriteBatch.DrawString(game._spriteFont, cd.ToString(), new Vector2(icon_x + icon_offset_x + offset, icon_y), Color.Red);
                }
            }
        }

        public void Update(float newStartX, float newStartY)
        {
            bar_x = (int)newStartX;
            bar_y = (int)newStartY + bar_preY;
            icon_x = bar_x;
            icon_y = bar_y;
        }
    }
}
