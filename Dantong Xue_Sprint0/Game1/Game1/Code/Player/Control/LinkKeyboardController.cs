using System.Collections.Generic;
using Game1.Code.Player.Control.PlayerControlCommand;
using Game1.Code.Player.Interface;
using Microsoft.Xna.Framework.Input;

namespace Game1.Code.Player.Control
{
    public class LinkKeyboardController 
    {
        private Dictionary<Keys, IPlayerCommand> controllerMappings;
        private Game1 game;
        public int boomerangIndex = -1;

        public LinkKeyboardController(Game1 game)
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
            RegisterCommand(Keys.N, new Attack(game));
            RegisterCommand(Keys.J, new Jump(game));
            RegisterCommand(Keys.K, new Dash(game));
            RegisterCommand(Keys.Z, new UseItem(game));
            RegisterCommand(Keys.D1, new UseAbility(game));

            RegisterCommand(Keys.M, new Respawn(game));


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
