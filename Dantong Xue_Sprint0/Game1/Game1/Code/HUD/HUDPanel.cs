using Game1.Code.HUD.Sprite;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Game1.Code.HUD
{
    class HUDPanel
    {
        private Game1 game;

        private int scale;
        private int level;
        private int rollingSpeed;

        private IHUDSprite HUDFrame;
        private IHUDSprite inventoryFrame;
        private IHUDSprite dungeonPauseScreenFrame;
        private IHUDSprite dungeonMiniMapFrame;

        // for test
        bool pause;
        public HUDPanel(Game1 game)
        {
            this.game = game;

            scale = (int)LoadAll.Instance.scale;
            level = 1;
            rollingSpeed = 8;

            HUDFrame = new HUDFrame();
            inventoryFrame = new InventoryFrame();
            dungeonPauseScreenFrame = new DungeonPauseScreenFrame();
            dungeonMiniMapFrame = new DungeonMiniMapFrame(level);

            // for test
            pause = false;
        }

        public void HUDUpdate()
        {
            // for test
            pause = Keyboard.GetState().IsKeyDown(Keys.L);
            //

            HUDFrame.Update(pause, rollingSpeed);
            inventoryFrame.Update(pause, rollingSpeed);
            dungeonPauseScreenFrame.Update(pause, rollingSpeed);
            dungeonMiniMapFrame.Update(pause, rollingSpeed);

        }

        public void HUDDraw()
        {
            HUDFrame.Draw(game._spriteBatch);
            inventoryFrame.Draw(game._spriteBatch);
            dungeonPauseScreenFrame.Draw(game._spriteBatch);
            dungeonMiniMapFrame.Draw(game._spriteBatch);
        }

    }
}
