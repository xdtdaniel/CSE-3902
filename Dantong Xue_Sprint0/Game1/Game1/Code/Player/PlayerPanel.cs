using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Game1.Code.Player;
using Game1.Code.LoadFile;
using Game1.Code.Item.ItemInterface;

namespace Game1
{
    public class PlayerPanel
    {
        private Game1 game;
        private LinkKeyboardController linkKeyboardController;

        // test
        private Dictionary<string, List<Rectangle>> roomBlockList;
        private List<Tuple<IEnemy, string>> roomEnemyList;
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
            roomEnemyList = new List<Tuple<IEnemy, string>>();
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
            PlayerItemAndBlockCollisionHandler.HandleCollision(game.link.itemPool, roomBlockList);
            PlayerItemAndEnemyCollisionHandler.HandleCollision(game.link.itemPool, roomEnemyList);
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

            if(game.link.itemList["Triforce"] > 0 && !game.link.isDead)
            {
                game.link.movable = false;
                game.link.Win();
                LoadAll.Instance.ChangeMapColor(Color.Yellow);
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
            //

            // for collision test
            string x = "x: " + game.link.x.ToString();
            string y = "y: " + game.link.y.ToString();
            string container = "container: " + game.link.itemList["HeartContainer"].ToString();
            string hp = "hp: " + game.link.itemList["Heart"].ToString();


            game._spriteBatch.DrawString(game._spriteFont, x, new Vector2(game.link.x, game.link.y - 125), Color.Black);
            game._spriteBatch.DrawString(game._spriteFont, y, new Vector2(game.link.x, game.link.y - 100), Color.Black);
            game._spriteBatch.DrawString(game._spriteFont, container, new Vector2(game.link.x, game.link.y - 75), Color.Black);
            game._spriteBatch.DrawString(game._spriteFont, hp, new Vector2(game.link.x, game.link.y - 50), Color.Black);
        }

    }
}
