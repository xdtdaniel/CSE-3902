﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.LoadFile
{
    class MouseMapController:IController
    {
        private MouseState oldState;
        private MouseState newState;

        public MouseMapController()
        {

        }

        public void Update(Game1 g)
        {
            newState = Mouse.GetState();

            if(newState.LeftButton == ButtonState.Pressed && oldState.LeftButton != ButtonState.Pressed)
            {
                LoadAll.Instance.NextMap();
                
                g.EnemyLoader.Next();
                g.ItemLoader.Next();
                g.link.ResetPos();
                
            }
            else if (newState.RightButton == ButtonState.Pressed && oldState.RightButton != ButtonState.Pressed)
            {
                LoadAll.Instance.PrevMap();

                g.EnemyLoader.Previous();
                g.ItemLoader.Previous();
                g.link.ResetPos();
            }

            oldState = newState;
        }
    }
}
