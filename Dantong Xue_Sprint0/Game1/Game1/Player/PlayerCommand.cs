
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
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
                game.link.UseItem(kc.ItemNum());
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

        }
    }
}
