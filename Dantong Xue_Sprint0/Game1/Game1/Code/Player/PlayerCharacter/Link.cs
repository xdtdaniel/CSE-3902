using Microsoft.Xna.Framework.Graphics;
using Game1.Player.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Game1.Code.Player;
using Game1.Enemy;

namespace Game1.Player.PlayerCharacter
{
    public class Link
    {
        public int x;
        public int y;
        public int damageTimeCounter;
        public bool isDamaged;
        public int hp;
        public int defaultSpeed;
        public int downSpeed, upSpeed, rightSpeed, leftSpeed;

        public string direction;

        PlayerItem item;

        private int scaler;

        public IPlayerLinkState state;
        public Link()
        {
            x = 300;
            y = 300;
            damageTimeCounter = 0;
            isDamaged = false;
            hp = 100;
            defaultSpeed = downSpeed = upSpeed = rightSpeed = leftSpeed = 5;

            direction = "down";

            

            state = new NormalLink(this);

            item = new PlayerItem();
            item.state = new NoItem(item);

            scaler = 1; // default size is 48 * 48

        }

        public void AttackN()
        {
            state.AttackN();
        }
        public void AttackZ()
        {
            state.AttackZ();
        }
        public void UseItem(int itemNum)
        {
            state.UseItem();
            item.UseItem(itemNum);
        }
        public void TakeDamage()
        {
            state.TakeDamage();
        }
        public void PickUp(int pickUp)
        {
            state.PickUp(pickUp);
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(x, y, 48 * scaler, 48 * scaler);
        }
        public void KnockedBack(string collisionSide)
        {
            state.KnockedBack(collisionSide);
        }
        public void Update(bool isMoving)
        {
            int directionIndex = 0;
            switch (direction)
            {
                case "down":
                    directionIndex = 0;
                    break;
                case "right":
                    directionIndex = 1;
                    break;
                case "up":
                    directionIndex = 2;
                    break;
                case "left":
                    directionIndex = 3;
                    break;
                default:
                    break;
            }
            state.Update(ref x, ref y, directionIndex, isMoving);
            item.Update(x, y, directionIndex);
            
           
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int directionIndex = 0;
            switch (direction)
            {
                case "down":
                    directionIndex = 0;
                    break;
                case "right":
                    directionIndex = 1;
                    break;
                case "up":
                    directionIndex = 2;
                    break;
                case "left":
                    directionIndex = 3;
                    break;
                default:
                    break;
            }
            state.Draw(spriteBatch, x, y, directionIndex);
            item.Draw(spriteBatch);
        }
    }
}
