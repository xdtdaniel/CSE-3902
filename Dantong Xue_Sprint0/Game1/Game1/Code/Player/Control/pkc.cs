using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.Player.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class pkc 
    {
        private Dictionary<Keys, IPlayerCommand> controllerMappings;

        public pkc()
        {
            controllerMappings = new Dictionary<Keys, IPlayerCommand>();


        }
        public void RegisterCommand(Keys key, IPlayerCommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                controllerMappings[key].Execute();
            }
        }
    }
}
