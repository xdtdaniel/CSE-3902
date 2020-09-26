
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Player.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2
{
    class PlayerCommand
    {
        private SpriteBatch spriteBatch;
        private Game1 game;
        public PlayerCommand(SpriteBatch spriteBatch, Game1 game)
        {
            this.spriteBatch = spriteBatch;
            this.game = game;
        }

        public void PlayerUpdate()
        {

            game.keyboardController.Update();

            game.link.Update(game.keyboardController.Direction(), game.keyboardController.IsMoving());
            game.item.Update(game.link.x, game.link.y, game.keyboardController.Direction());
        }
        public void PlayerDraw()
        {


            if (game.keyboardController.PressedAttackN())
            {
                game.link.AttackN();
            }
            else if (game.keyboardController.PressedAttackZ())
            {
                game.link.AttackZ();
            }
            if (game.keyboardController.ItemNum() != -1)
            {
                game.link.UseItem();
                game.item.UseItem(game.keyboardController.ItemNum());
            }
            if (game.keyboardController.IsDamaged())
            {
                game.link.TakeDamage();
            }
            if (game.keyboardController.PickUp() != -1)
            {
                game.link.PickUp(game.keyboardController.PickUp());
            }
            game.link.Draw(spriteBatch, game.keyboardController.Direction());
            game.item.Draw(spriteBatch);

        }
    }
}
