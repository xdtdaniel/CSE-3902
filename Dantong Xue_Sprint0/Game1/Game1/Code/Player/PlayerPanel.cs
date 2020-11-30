using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Game1.Code.LoadFile;
using Game1.Code.Item.ItemInterface;
using Game1.Code.Player.Control;
using Game1.Code.Player.CollisionHandler;
using System.Diagnostics;

namespace Game1.Code.Player
{
    public class PlayerPanel
    {
        private Game1 game;
        public LinkKeyboardController linkKeyboardController;

        // test
        private Dictionary<string, List<Rectangle>> roomBlockList;
        private List<Tuple<IEnemy, string, int>> roomEnemyList;
        private List<Tuple<IItemSprite, string>> roomItemList;
        private List<IBlock> movableList;

        private bool clockWorking;

        //
        public PlayerPanel(Game1 game)
        {
            this.game = game;
            linkKeyboardController = new LinkKeyboardController(game);

            //
            roomBlockList = new Dictionary<string, List<Rectangle>>();
            roomEnemyList = new List<Tuple<IEnemy, string, int>>();
            roomItemList = new List<Tuple<IItemSprite, string>>();
            movableList = new List<IBlock>();


            //
            clockWorking = false;
        }
        public bool checkClockActivation()
        {
            if (game.link.itemList["Clock"] > 0)
            {
                game.link.itemList["Clock"] = 0;
                clockWorking = true;
            }
            if (PlayerAndBlockCollisionHandler.doorSide != "")
            {
                clockWorking = false;
                game.link.isInvincible = false;
            }
            return clockWorking;
        }

        public void PlayerUpdate()
        {
            game.link.Update();
            linkKeyboardController.Update();


            roomBlockList = LoadAll.Instance.GetMapArtifacts();
            roomEnemyList = game.EnemyList;
            roomItemList = game.inRoomList;
            movableList = game.movableBlocks;

            PlayerAndBlockCollisionHandler.HandleCollision(game.link, roomBlockList);
            PlayerAndEnemyCollisionHandler.HandleCollision(game.link, roomEnemyList);
            PlayerItemAndBlockCollisionHandler.HandleCollision(game.link, roomBlockList);
            PlayerItemAndEnemyCollisionHandler.HandleCollision(game.link, roomEnemyList);
            PlayerAndItemCollisionHandler.HandleCollision(game.link, roomItemList);
            PlayerAndBlockCollisionHandler.HandleMovableCollision(game.link, movableList);
            //


            if (game.link.itemList["Heart"] <= 0 && !game.link.isDead)
            {
                game.link.movable = false;
                if (game.link.damageTimeCounter == 0)
                {
                    game.link.Die();
                    LoadAll.Instance.ChangeMapColor(Color.Red);
                }
            }

            //similar to normal link state, but link won't get demage, when hold clock at current room
            if (clockWorking && !game.link.isDead)
            {
                game.link.movable = true;
                game.link.isInvincible = true;
                
            }

        }
        public void PlayerDraw()
        {
            game.link.Draw(game._spriteBatch);
            //string x = "x" + game.link.x.ToString();
            //string y = "y" + game.link.y.ToString();

            //game._spriteBatch.DrawString(game._spriteFont, x, new Vector2(LoadAll.Instance.startPos.X + 200, LoadAll.Instance.startPos.Y + 200), Color.White);
            //game._spriteBatch.DrawString(game._spriteFont, y, new Vector2(LoadAll.Instance.startPos.X + 100, LoadAll.Instance.startPos.Y + 200), Color.White);
        }
    }
}
