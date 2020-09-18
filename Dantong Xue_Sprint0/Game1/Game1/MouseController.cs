using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class MouseController : IController
    {

        private MouseState oldState;
        private MouseState newState;
        private Command.Actions curr_act;
        private Command command;
        private bool act_change;

        private Dictionary<int, Command.Actions> quadMap;

        public MouseController(Game1 g)
        {
            quadMap = new Dictionary<int, Command.Actions>();
            quadMap.Add(1, Command.Actions.non_moving_still);
            quadMap.Add(2, Command.Actions.non_moving_animated);
            quadMap.Add(3, Command.Actions.moving_still);
            quadMap.Add(4, Command.Actions.moving_animated);

            curr_act = Command.Actions.non_moving_still;

            command = g.command;
        }


        public void Update(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Game1 g)
        {
            newState = Mouse.GetState();

            float x = newState.X;
            float y = newState.Y;

            int quad = 0;

            if (x < 400)
            {
                if (y < 240)
                {
                    quad = 1;
                }
                else
                {
                    quad = 3;
                }
            }
            else
            {
                if (y < 240)
                {
                    quad = 2;
                }
                else
                {
                    quad = 4;
                }
            }

            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                this.curr_act = quadMap[quad];
                act_change = true;
            }

            if (newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
            {
                this.curr_act = Command.Actions.exit;
                act_change = true;
            }

                Command.Actions prev = command.getPrev();
            if (prev == Command.Actions.none && act_change)
            {
                command.Execute(curr_act, g, spriteBatch);
                act_change = false;
            }

            oldState = newState;
        }
    }
}
