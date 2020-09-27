
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
        private PlayerKeyboardController kc;
        public PlayerCommand(SpriteBatch spriteBatch, Game1 game)
        {
            this.spriteBatch = spriteBatch;
            this.game = game;
            kc = new PlayerKeyboardController();
        }

        public void PlayerUpdate()
        {

            kc.Update();

            game.link.Update(kc.Direction(), kc.IsMoving());
            game.item.Update(game.link.x, game.link.y, kc.Direction());
        }
        public void PlayerDraw()
        {


            if (kc.PressedAttackN())
            {
                game.link.AttackN();
            }
            else if (kc.PressedAttackZ())
            {
                game.link.AttackZ();
            }
            if (kc.ItemNum() != -1)
            {
                game.link.UseItem();
                game.item.UseItem(kc.ItemNum());
            }
            if (kc.IsDamaged())
            {
                game.link.TakeDamage();
            }
            if (kc.PickUp() != -1)
            {
                game.link.PickUp(kc.PickUp());
            }
            game.link.Draw(spriteBatch, kc.Direction());
            game.item.Draw(spriteBatch);

        }
    }
}
