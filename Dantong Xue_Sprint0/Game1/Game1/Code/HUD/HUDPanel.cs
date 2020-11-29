using Game1.Code.Achievement;
using Game1.Code.HUD.AbilitySelection;
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

        private List<IHUDSprite> hudList = new List<IHUDSprite>();

        private ItemSelectionController itemSelectionController;
        private AbilitySelectionController abilitySelectionController;

        private AchievementPanel achievementPanel;

        public HUDPanel(Game1 game)
        {
            this.game = game;

            inventoryItemList = new List<Tuple<string, int>>();

            hudList.Add(new HUDFrame());
            hudList.Add(new InventoryFrame());
            hudList.Add(new DungeonPauseScreenFrame());
            hudList.Add(new DungeonMiniMapFrame(level));
            hudList.Add(new HUDSymbol());
            hudList.Add(new HUDNumberOfHeart(game.link.itemList));
            hudList.Add(new HUDNumberOfBomb(game.link.itemList));
            hudList.Add(new HUDNumberOfKey(game.link.itemList));
            hudList.Add(new HUDNumberOfRuby(game.link.itemList));
            hudList.Add(new DungeonMiniMap(game.link.itemList));
            hudList.Add(new DungeonPauseScreen(game.link.itemList));
            hudList.Add(new DisplayPause(game));
            hudList.Add(new DashChargeIndicator(game));
            hudList.Add(new AbilityTreeFrame());
            hudList.Add(new AbilityBar());
            hudList.Add(new HUDExp(game.link.expCount));

            itemSelectionController = new ItemSelectionController(game, inventoryItemList);
            abilitySelectionController = new AbilitySelectionController(game.link.playerAbilityPanel);

            achievementPanel = new AchievementPanel(game);


        }
        public void HUDUpdate()
        {

            string side = PlayerAndBlockCollisionHandler.doorSide;
            bool switched = PlayerAndBlockCollisionHandler.roomSwitched;
            int targetX = (int)LoadAll.Instance.startPos.X;
            int targetY = (int)LoadAll.Instance.startPos.Y;

            for (int i = 0; i < hudList.Count; i++)
            {
                hudList[i].Update(x, y);
            }

            itemSelectionController.Update(x, y);
            abilitySelectionController.Update(x, y);
            achievementPanel.Update((int)x, (int)y);

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
            for (int i = 0; i < hudList.Count; i++)
            {
                hudList[i].Draw(game._spriteBatch);
            }

            itemSelectionController.Draw();
            abilitySelectionController.Draw(game._spriteBatch);
            achievementPanel.Draw();
        }

    }
}
