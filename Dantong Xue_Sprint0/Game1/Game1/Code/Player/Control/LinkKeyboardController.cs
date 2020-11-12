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
        int boomerangIndex;

        public LinkKeyboardController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, IPlayerCommand>();
            this.game = game;
            boomerangIndex = -1;

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
            RegisterCommand(Keys.Z, new UseItem(game));


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

            if (boomerangIndex == -1 && game.selectedItemName == "Boomerang")
            {
                boomerangIndex = game.link.itemIndex;
            }
            if (boomerangIndex != -1 && game.link.itemPool[boomerangIndex].IsDone())
            {
                boomerangIndex = -1;
                game.link.itemList["Boomerang"] = 1;
            }
        }
    }
}
