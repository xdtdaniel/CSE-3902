
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
        private SpriteBatch spriteBatch;
        private Game1 game;
        private PlayerKeyboardController keyBoardController;

        // test
        private Dictionary<string, List<Rectangle>> roomBlockList;
        private List<Tuple<IEnemy, string>> roomEnemyList;
        private List<Tuple<IItemSprite, string>> roomItemList;

        private PlayerAndBlockCollisionHandler playerAndBlockCollisionHandler;
        private PlayerAndEnemyCollisionHandler playerAndEnemyCollisionHandler;
        private PlayerItemaAndBlockCollisionHandler playerItemAndBlockCollisionHandler;
        private PlayerAndItemCollisionHandler playerAndItemCollisionHandler;
        //
        public PlayerPanel(SpriteBatch spriteBatch, Game1 game)
        {
            this.spriteBatch = spriteBatch;
            this.game = game;
            keyBoardController = new PlayerKeyboardController(game);

            //
            roomBlockList = new Dictionary<string, List<Rectangle>>();
            roomEnemyList = new List<Tuple<IEnemy, string>>();
            roomItemList = new List<Tuple<IItemSprite, string>>();

            playerAndBlockCollisionHandler = new PlayerAndBlockCollisionHandler();
            playerAndEnemyCollisionHandler = new PlayerAndEnemyCollisionHandler();
            playerItemAndBlockCollisionHandler = new PlayerItemaAndBlockCollisionHandler();
            playerAndItemCollisionHandler = new PlayerAndItemCollisionHandler();
            //
        }

        public void PlayerUpdate(List<Tuple<IEnemy, string>> enemyList, List<Tuple<IItemSprite,string>> inRoomItemList)
        {
            game.link.Update();
            keyBoardController.Update();


            roomBlockList = LoadAll.Instance.GetMapArtifacts();
            roomEnemyList = enemyList;
            roomItemList = inRoomItemList;
            playerAndBlockCollisionHandler.HandleCollision(game.link, roomBlockList);
            playerAndEnemyCollisionHandler.HandleCollision(game.link, roomEnemyList);
            playerItemAndBlockCollisionHandler.HandleCollision(game.link.item, roomBlockList);
            playerAndItemCollisionHandler.HandleCollision(game.link, roomItemList);
            //
        }
        public void PlayerDraw()
        {
            game.link.Draw(spriteBatch);


            // for collision test
            string x = "x: " + game.link.x.ToString();
            string y = "y: " + game.link.y.ToString();
            string damagedTimeRemain = "time: " + game.link.damageTimeCounter.ToString();
            string hp = "hp: " + game.link.hp.ToString();


            spriteBatch.DrawString(game._spriteFont, x, new Vector2(game.link.x, game.link.y - 125), Color.Black);
            spriteBatch.DrawString(game._spriteFont, y, new Vector2(game.link.x, game.link.y - 100), Color.Black);
            spriteBatch.DrawString(game._spriteFont, damagedTimeRemain, new Vector2(game.link.x, game.link.y - 75), Color.Black);
            spriteBatch.DrawString(game._spriteFont, hp, new Vector2(game.link.x, game.link.y - 50), Color.Black);
        }
    }
}
