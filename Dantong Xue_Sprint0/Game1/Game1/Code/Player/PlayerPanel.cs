
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Code.Player;
using Game1.Player.Interface;
using Game1.Enemy;
using Game1.Code.LoadFile;
using Game1.Code.Player.PlayerItem.PlayerItemSprite;
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

        private PlayerAndBlockCollisionHandler playerAndBlockCollisionHandler;
        private PlayerAndEnemyCollisionHandler playerAndEnemyCollisionHandler;
        private PlayerItemaAndBlockCollisionHandler playerItemAndBlockCollisionHandler;
        private PlayerAndItemCollisionHandler playerAndItemCollisionHandler;
        private PlayerItemaAndEnemyCollisionHandler playerItemaAndEnemyCollisionHandler;
        //
        public PlayerPanel(Game1 game)
        {
            this.game = game;
            linkKeyboardController = new LinkKeyboardController(game);

            //
            roomBlockList = new Dictionary<string, List<Rectangle>>();
            roomEnemyList = new List<Tuple<IEnemy, string>>();
            roomItemList = new List<Tuple<IItemSprite, string>>();

            playerAndBlockCollisionHandler = new PlayerAndBlockCollisionHandler();
            playerAndEnemyCollisionHandler = new PlayerAndEnemyCollisionHandler();
            playerItemAndBlockCollisionHandler = new PlayerItemaAndBlockCollisionHandler();
            playerAndItemCollisionHandler = new PlayerAndItemCollisionHandler();
            playerItemaAndEnemyCollisionHandler = new PlayerItemaAndEnemyCollisionHandler();
            //
        }

        public void PlayerUpdate()
        {
            game.link.Update();
            linkKeyboardController.Update();


            roomBlockList = LoadAll.Instance.GetMapArtifacts();
            roomEnemyList = game.EnemyList;
            roomItemList = game.inRoomList;
            playerAndBlockCollisionHandler.HandleCollision(game.link, roomBlockList);
            playerAndEnemyCollisionHandler.HandleCollision(game.link, roomEnemyList);
            playerItemAndBlockCollisionHandler.HandleCollision(game.link.item, roomBlockList);
            playerAndItemCollisionHandler.HandleCollision(game.link, roomItemList);
            playerItemaAndEnemyCollisionHandler.HandleCollision(game.link.item, roomEnemyList);
            //
        }
        public void PlayerDraw()
        {
            game.link.Draw(game._spriteBatch);
            //

            // for collision test
            string x = "x: " + game.link.x.ToString();
            string y = "y: " + game.link.y.ToString();
            string damagedTimeRemain = "time: " + game.link.damageTimeCounter.ToString();
            string hp = "hp: " + game.link.hp.ToString();


            game._spriteBatch.DrawString(game._spriteFont, x, new Vector2(game.link.x, game.link.y - 125), Color.Black);
            game._spriteBatch.DrawString(game._spriteFont, y, new Vector2(game.link.x, game.link.y - 100), Color.Black);
            game._spriteBatch.DrawString(game._spriteFont, damagedTimeRemain, new Vector2(game.link.x, game.link.y - 75), Color.Black);
            game._spriteBatch.DrawString(game._spriteFont, hp, new Vector2(game.link.x, game.link.y - 50), Color.Black);
        }
    }
}
