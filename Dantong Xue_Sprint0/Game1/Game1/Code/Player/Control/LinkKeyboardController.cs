using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerControlCommand;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class LinkKeyboardController 
    {
        private Dictionary<Keys, IPlayerCommand> controllerMappings;
        private Game1 game;

        public LinkKeyboardController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, IPlayerCommand>();
            this.game = game;

            RegisterCommand(Keys.S, new MoveDown(game));
            RegisterCommand(Keys.D, new MoveRight(game));
            RegisterCommand(Keys.W, new MoveUp(game));
            RegisterCommand(Keys.A, new MoveLeft(game));
            //RegisterCommand(Keys.Down, new MoveDown(game));
            //RegisterCommand(Keys.Right, new MoveRight(game));
            //RegisterCommand(Keys.Up, new MoveUp(game));
            //RegisterCommand(Keys.Left, new MoveLeft(game));
            RegisterCommand(Keys.N, new Attack(game));

            // change key Z to use current item later
            RegisterCommand(Keys.Z, new Attack(game));


            RegisterCommand(Keys.D1, new UseItem(game, "Arrow"));
            RegisterCommand(Keys.D2, new UseItem(game, "Boomerang"));
            RegisterCommand(Keys.D3, new UseItem(game, "Bomb"));
            RegisterCommand(Keys.D4, new UseItem(game, "BlueCandle"));
            RegisterCommand(Keys.D5, new UseItem(game, "BluePotion"));
            RegisterCommand(Keys.D6, new UseItem(game, "BlueRing"));

        }
        public void RegisterCommand(Keys key, IPlayerCommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            game.link.isMoving = false;
            
            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
            }
        }
    }
}
