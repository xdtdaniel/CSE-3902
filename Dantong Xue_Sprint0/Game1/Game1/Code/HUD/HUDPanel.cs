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
        private IHUDSprite hudSymbol;
        private IHUDSprite hudNumberOfHeart;
        private IHUDSprite hudNumberOfBomb;
        private IHUDSprite hudNumberOfKey;
        private IHUDSprite hudNumberOfRuby;

        // for test
        bool pause;
        public HUDPanel(Game1 game)
        {
            this.game = game;

            scale = (int)LoadAll.Instance.scale;
            level = 1;
            rollingSpeed = 3 * scale;

            HUDFrame = new HUDFrame();
            inventoryFrame = new InventoryFrame();
            dungeonPauseScreenFrame = new DungeonPauseScreenFrame();
            dungeonMiniMapFrame = new DungeonMiniMapFrame(level);
            hudSymbol = new HUDSymbol();
            hudNumberOfHeart = new HUDNumberOfHeart(game.link.itemList);
            hudNumberOfBomb = new HUDNumberOfBomb(game.link.itemList);
            hudNumberOfKey = new HUDNumberOfKey(game.link.itemList);
            hudNumberOfRuby = new HUDNumberOfRuby(game.link.itemList);

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
            hudSymbol.Update(pause, rollingSpeed);
            hudNumberOfHeart.Update(pause, rollingSpeed);
            hudNumberOfBomb.Update(pause, rollingSpeed);
            hudNumberOfKey.Update(pause, rollingSpeed);
            hudNumberOfRuby.Update(pause, rollingSpeed);
        }

        public void HUDDraw()
        {
            HUDFrame.Draw(game._spriteBatch);
            inventoryFrame.Draw(game._spriteBatch);
            dungeonPauseScreenFrame.Draw(game._spriteBatch);
            dungeonMiniMapFrame.Draw(game._spriteBatch);
            hudSymbol.Draw(game._spriteBatch);
            hudNumberOfHeart.Draw(game._spriteBatch);
            hudNumberOfBomb.Draw(game._spriteBatch);
            hudNumberOfKey.Draw(game._spriteBatch);
            hudNumberOfRuby.Draw(game._spriteBatch);
        }

    }
}
