using Game1.Code.HUD.ItemSelection;
using Game1.Code.HUD.Sprite;
using Game1.Code.LoadFile;
using Game1.Code.Player.CollisionHandler;
using System;
using System.Collections.Generic;

namespace Game1.Code.HUD
{
    public class HUDPanel
    {
        private Game1 game;

        private static int scale = (int)LoadAll.Instance.scale;
        private int level = 1;
        private float shiftingSpeed = (float)16 / 3 * scale;    // speed for shifting hud while changing room
        public float x = (int)LoadAll.Instance.startPos.X;
        public float y = (int)LoadAll.Instance.startPos.Y;

        private List<Tuple<string, int>> inventoryItemList;

        private IHUDSprite HUDFrame;
        private IHUDSprite inventoryFrame;
        private IHUDSprite dungeonPauseScreenFrame;
        private IHUDSprite dungeonMiniMapFrame;
        private IHUDSprite hudSymbol;
        private IHUDSprite hudNumberOfHeart;
        private IHUDSprite hudNumberOfBomb;
        private IHUDSprite hudNumberOfKey;
        private IHUDSprite hudNumberOfRuby;
        private IHUDSprite dungeonMiniMap;
        private IHUDSprite dungeonPauseScreen;
        private IHUDSprite displayPause;
        private IHUDSprite dashChargeIndicator;

        private ItemSelectionController itemSelectionController;


        public HUDPanel(Game1 game)
        {
            this.game = game;

            inventoryItemList = new List<Tuple<string, int>>();

            HUDFrame = new HUDFrame();
            inventoryFrame = new InventoryFrame();
            dungeonPauseScreenFrame = new DungeonPauseScreenFrame();
            dungeonMiniMapFrame = new DungeonMiniMapFrame(level);
            hudSymbol = new HUDSymbol();
            hudNumberOfHeart = new HUDNumberOfHeart(game.link.itemList);
            hudNumberOfBomb = new HUDNumberOfBomb(game.link.itemList);
            hudNumberOfKey = new HUDNumberOfKey(game.link.itemList);
            hudNumberOfRuby = new HUDNumberOfRuby(game.link.itemList);
            dungeonMiniMap = new DungeonMiniMap(game.link.itemList);
            dungeonPauseScreen = new DungeonPauseScreen(game.link.itemList);
            displayPause = new DisplayPause(game);
            dashChargeIndicator = new DashChargeIndicator(game);

            itemSelectionController = new ItemSelectionController(game, inventoryItemList);


        }
        public void HUDUpdate()
        {

            string side = PlayerAndBlockCollisionHandler.doorSide;
            bool switched = PlayerAndBlockCollisionHandler.roomSwitched;
            int targetX = (int)LoadAll.Instance.startPos.X;
            int targetY = (int)LoadAll.Instance.startPos.Y;

            HUDFrame.Update(x, y);
            inventoryFrame.Update(x, y);
            dungeonPauseScreenFrame.Update(x, y);
            dungeonMiniMapFrame.Update(x, y);
            hudSymbol.Update(x, y);
            hudNumberOfHeart.Update(x, y);
            hudNumberOfBomb.Update(x, y);
            hudNumberOfKey.Update(x, y);
            hudNumberOfRuby.Update(x, y);
            dungeonMiniMap.Update(x, y);
            dungeonPauseScreen.Update(x, y);
            itemSelectionController.Update(x,y);
            displayPause.Update(x, y);
            dashChargeIndicator.Update(x, y);

            if (switched)
            {
                switch (side)
                {
                    case "up":
                        if (y > targetY)
                        {
                            y -= shiftingSpeed;
                        }
                        else
                        {
                            y = targetY;
                            PlayerAndBlockCollisionHandler.roomSwitched = false;
                        }
                        break;
                    case "down":
                        if (y < targetY)
                        {
                            y += shiftingSpeed;
                        }
                        else
                        {
                            y = targetY;
                            PlayerAndBlockCollisionHandler.roomSwitched = false;
                        }
                        break;
                    case "left":
                        if (x > targetX)
                        {
                            x -= shiftingSpeed;
                        }
                        else
                        {
                            x = targetX;
                            PlayerAndBlockCollisionHandler.roomSwitched = false;
                        }
                        break;
                    case "right":
                        if (x < targetX)
                        {
                            x += shiftingSpeed;
                        }
                        else
                        {
                            x = targetX;
                            PlayerAndBlockCollisionHandler.roomSwitched = false;
                        }
                        break;
                    default:
                        break;
                }
            }
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
            dungeonMiniMap.Draw(game._spriteBatch);
            dungeonPauseScreen.Draw(game._spriteBatch);
            itemSelectionController.Draw();
            displayPause.Draw(game._spriteBatch);
            dashChargeIndicator.Draw(game._spriteBatch);

        }

    }
}
