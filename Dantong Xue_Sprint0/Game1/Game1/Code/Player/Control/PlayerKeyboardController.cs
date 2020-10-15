using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class PlayerKeyboardController : IPlayerController
    {
        private string direction;
        private bool isMoving;
        private bool attackN;
        private bool attackZ;
        private int itemNum;
        private bool isDamaged;
        private int pickUp;

        public string side;
        public PlayerKeyboardController()
        {
            direction = "down";
            isMoving = false;
            attackN = false;
            attackZ = false;
            itemNum = -1;
            isDamaged = false;
            pickUp = -1;
            
            side = "";   // test collision
        }
        public void Update()
        {
            side = "";   // test collision

            isMoving = false;
            attackN = false;
            attackZ = false;
            itemNum = -1;
            isDamaged = false;
            pickUp = -1;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.N))
            {
                attackN = true;
            }
            else if (state.IsKeyDown(Keys.Z))
            {
                attackZ = true;
            }
            else if (state.IsKeyDown(Keys.D1))
            {
                itemNum = 1;
            }
            else if (state.IsKeyDown(Keys.D2))
            {
                itemNum = 2;
            }
            else if (state.IsKeyDown(Keys.D3))
            {
                itemNum = 3;
            }
            else if (state.IsKeyDown(Keys.D4))
            {
                itemNum = 4;
            }
            else if (state.IsKeyDown(Keys.D5))
            {
                itemNum = 5;
            }
            else if (state.IsKeyDown(Keys.D6))
            {
                itemNum = 6;
            }
            else if (state.IsKeyDown(Keys.D7))
            {
                itemNum = 7;
            }
            else if (state.IsKeyDown(Keys.D8))
            {
                itemNum = 8;
            }
            else if (state.IsKeyDown(Keys.E))
            {
                isDamaged = true;
            }
            else if (state.IsKeyDown(Keys.F))
            {
                pickUp = 0;
            }
            else if (state.IsKeyDown(Keys.G))
            {
                pickUp = 1;
            }
            else if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down))
            {
                direction = "down";
                isMoving = true;
            }
            else if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
            {
                direction = "right";
                isMoving = true;
            }
            else if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up))
            {
                direction = "up";
                isMoving = true;
            }
            else if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
            {
                direction = "left";
                isMoving = true;
            }
            // collision test
            else if (state.IsKeyDown(Keys.X))
            {
                side = "down";
            }
            else if (state.IsKeyDown(Keys.C))
            {
                side = "right";
            }
            else if (state.IsKeyDown(Keys.V))
            {
                side = "up";
            }
            else if (state.IsKeyDown(Keys.B))
            {
                side = "left";
            }


            else
            {
                isMoving = false;
            }
        }

        public string Direction()
        {
            return direction;
        }
        public bool IsMoving()
        {
            return isMoving;
        }
        public bool PressedAttackN()
        {
            return attackN;
        }
        public bool PressedAttackZ()
        {
            return attackZ;
        }
        public int ItemNum()
        {
            return itemNum;
        }
        public bool IsDamaged()
        {
            return isDamaged;
        }
        public int PickUp()
        {
            return pickUp;
        }
    }
}
