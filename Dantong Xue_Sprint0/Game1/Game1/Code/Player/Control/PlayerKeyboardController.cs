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
    public class PlayerKeyboardController 
    {
        private Dictionary<Keys, IPlayerCommand> controllerMappings;
        private Game1 game;

        public PlayerKeyboardController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, IPlayerCommand>();
            this.game = game;

            RegisterCommand(Keys.S, new MoveDown(game));
            RegisterCommand(Keys.D, new MoveRight(game));
            RegisterCommand(Keys.W, new MoveUp(game));
            RegisterCommand(Keys.A, new MoveLeft(game));
            RegisterCommand(Keys.Down, new MoveDown(game));
            RegisterCommand(Keys.Right, new MoveRight(game));
            RegisterCommand(Keys.Up, new MoveUp(game));
            RegisterCommand(Keys.Left, new MoveLeft(game));
            RegisterCommand(Keys.N, new Attack(game, 0));
            RegisterCommand(Keys.Z, new Attack(game, 1));
            RegisterCommand(Keys.D1, new UseItem(game, 1));
            RegisterCommand(Keys.D2, new UseItem(game, 2));
            RegisterCommand(Keys.D3, new UseItem(game, 3));
            RegisterCommand(Keys.D4, new UseItem(game, 4));
            RegisterCommand(Keys.D5, new UseItem(game, 5));
            RegisterCommand(Keys.D6, new UseItem(game, 6));

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
