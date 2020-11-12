using Game1.Code.HUD.Sprite;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game1.Code.HUD
{
    class HUDPanel
    {
        private Game1 game;

        private int scale;
        private int level;
        private int rollingSpeed;     // speed for hud to be drawn down when menu is called
        private float shiftingSpeed;    // speed for shifting hud while changing room
        public float x;
        public float y;
        private int yOrigin;
        private int yDistance;
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

        private ItemSelectionController itemSelectionController;
        private KeyboardState oldState;
        private KeyboardState newState;
        private bool paused;
        private bool clock;

        public HUDPanel(Game1 game)
        {
            this.game = game;

            scale = (int)LoadAll.Instance.scale;
            level = 1;
            rollingSpeed = 3 * scale;
            shiftingSpeed = (float)16/3 * scale;
            x = (int)LoadAll.Instance.startPos.X;
            y = (int)LoadAll.Instance.startPos.Y;
            yOrigin = (int)LoadAll.Instance.startPos.Y;
            yDistance = 176 * scale;
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
           // hudInventoryAB = new HUDInventoryAB(game.link.itemList);

            itemSelectionController = new ItemSelectionController(game, inventoryItemList);

            // for test
            paused = false;

        }
        public void HUDUpdate()
        {
            newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.P) && !oldState.IsKeyDown(Keys.P))
            {
                paused = !paused;

            }
            clock = itemSelectionController.getClock();
         

            oldState = newState;

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
           // hudInventoryAB.Update(x,y);
            itemSelectionController.Update(x,y);



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
                            yOrigin = (int)LoadAll.Instance.startPos.Y;
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
                            yOrigin = (int)LoadAll.Instance.startPos.Y;
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
            else if (paused)
            {
                if (y < yOrigin + yDistance)
                {
                    y += rollingSpeed;
                }
            }
            else
            {
                if (y > yOrigin)
                {
                    y -= rollingSpeed;
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

        }
        public bool IsPaused()
        {
            return paused;
        }
        public bool Clock()
        {
            return itemSelectionController.getClock();
            

        }
    }
}
