
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

namespace Game1
{
    public class PlayerCommand
    {
        private SpriteBatch spriteBatch;
        private Game1 game;

        // test
        private Dictionary<string, List<Rectangle>> blockList;
        private List<Tuple<IEnemy, string>> enemyList;
        private List<IBlock> movables;

        private PlayerBlockCollisionHandler playerBlockCollisionHandler;
        private PlayerEnemyCollisionHandler playerEnemyCollisionHandler;
        private ItemBlockCollisionHandler itemBlockCollisionHandler;

        public PlayerCommand(SpriteBatch spriteBatch, Game1 game)
        {
            this.spriteBatch = spriteBatch;
            this.game = game;

            //
            blockList = new Dictionary<string, List<Rectangle>>();
            enemyList = new List<Tuple<IEnemy, string>>();

            playerBlockCollisionHandler = new PlayerBlockCollisionHandler();
            playerEnemyCollisionHandler = new PlayerEnemyCollisionHandler();
            itemBlockCollisionHandler = new ItemBlockCollisionHandler();

        }

        public void PlayerUpdate()
        {
            game.link.direction = game.playerKeyboardController.Direction();
            game.link.Update(game.playerKeyboardController.IsMoving());


            blockList = LoadAll.Instance.GetMapArtifacts();
            movables = LoadAll.Instance.GetMovableBlocks();
            enemyList = LoadEnemy.Instance.GetEnemyList();
            playerBlockCollisionHandler.HandleCollision(game.link, blockList);
            playerBlockCollisionHandler.HandleMovableCollision(game.link, movables);
            playerEnemyCollisionHandler.HandleCollision(game.link, enemyList);
            itemBlockCollisionHandler.HandleCollision(game.link.item, blockList);
        }
        public void PlayerDraw()
        {


            if (game.playerKeyboardController.PressedAttackN())
            {
                game.link.AttackN();
            }
            else if (game.playerKeyboardController.PressedAttackZ())
            {
                game.link.AttackZ();
            }
            if (game.playerKeyboardController.ItemNum() != -1)
            {
                game.link.UseItem(game.playerKeyboardController.ItemNum());
            }
            if (game.playerKeyboardController.IsDamaged())
            {
                game.link.TakeDamage();
            }
            if (game.playerKeyboardController.PickUp() != -1)
            {
                game.link.PickUp(game.playerKeyboardController.PickUp());
            }
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
