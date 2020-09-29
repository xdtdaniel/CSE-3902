using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class KeyboardController : IController
    {

        private KeyboardState oldState;
        private KeyboardState newState;
        

        
        private bool act_change;
        private Command command;
        private Dictionary<Keys, Command.Actions> keymap;
        private Command.Actions prev_act;
        private Command.Actions curr_act;

        public KeyboardController(Game1 g)
        {
            keymap = new Dictionary<Keys, Command.Actions>();

            keymap.Add(Keys.D0, Command.Actions.exit);
            keymap.Add(Keys.NumPad0, Command.Actions.exit);
            keymap.Add(Keys.D1, Command.Actions.non_moving_still);
            keymap.Add(Keys.NumPad1, Command.Actions.non_moving_still);
            keymap.Add(Keys.D2, Command.Actions.non_moving_animated);
            keymap.Add(Keys.NumPad2, Command.Actions.non_moving_animated);
            keymap.Add(Keys.D3, Command.Actions.moving_still);
            keymap.Add(Keys.NumPad3, Command.Actions.moving_still);
            keymap.Add(Keys.D4, Command.Actions.moving_animated);
            keymap.Add(Keys.NumPad4, Command.Actions.moving_animated);

            command = g.command;

            curr_act = Command.Actions.non_moving_still;
            act_change = false;
        }

        public void Update(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Game1 g)
        {

            this.newState = Keyboard.GetState();

            foreach(var item in keymap)
            {
                if (this.newState.IsKeyDown(item.Key) && !this.oldState.IsKeyDown(item.Key))
                {
                    curr_act = item.Value;
                    act_change = true;
                }
            }

            Command.Actions prev = command.getPrev();
            if (prev == Command.Actions.none && act_change)
            { 
                command.Execute(curr_act, g, spriteBatch);
                act_change = false;
            }

            this.oldState = this.newState;
        }
    }
}
