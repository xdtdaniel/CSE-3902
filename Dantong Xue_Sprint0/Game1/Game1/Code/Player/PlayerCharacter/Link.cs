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
using Game1.Code.LoadFile;

namespace Game1.Player.PlayerCharacter
{
    public class Link
    {
        public int x;
        public int y;
        public int damageTimeCounter;
        public bool isDamaged;
        public bool isMoving;
        public bool movable;
        public int hp;
        public int defaultSpeed;
        public int xSpeed, ySpeed;

        public string direction;
        public int directionIndex;

        public LinkItem item;

        public int timeBetweenAttack;
        public int timeSinceAttack;
        public int timeBetweenItem;
        public int timeSinceItem;
        public bool useItemDone;


        public IPlayerLinkState state;
        public Link()
        {
            x = 300;
            y = 300;
            damageTimeCounter = 0;
            isDamaged = false;
            isMoving = false;
            movable = true;
            hp = 100;
            defaultSpeed = xSpeed = ySpeed = 5;

            direction = "down";
            directionIndex = 0;

            state = new NormalLink(this);

            item = new LinkItem();
            item.state = new NoItem(item);

            timeBetweenAttack = 45;
            timeSinceAttack = 0; 
            timeBetweenItem = 45;
            timeSinceItem = 0;
            useItemDone = true;

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
            return new Rectangle(x, y, (int)(13 * LoadAll.Instance.scale), (int)(13 * LoadAll.Instance.scale));
        }
        public void KnockedBack(string collisionSide)
        {
            movable = false;
            state.KnockedBack(collisionSide);
        }
        public void StopMoving(string side, Rectangle interRect)
        {
            if (side == "down")
            {
                y -= interRect.Height;
            }
            if (side == "right")
            {
                x -= interRect.Width;
            }
            if (side == "up")
            {
                y += interRect.Height;
            }
            if (side == "left")
            {
                x += interRect.Width;
            }
        }
        public void Update()
        {
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
            state.Update();
            item.Update(x, y, directionIndex);

            if (timeSinceAttack < timeBetweenAttack)
            {
                timeSinceAttack++;
            }
            if (timeSinceItem < timeBetweenItem)
            {
                timeSinceItem++;
            }

            if (isDamaged)
            {
                damageTimeCounter++;
            }
            if (damageTimeCounter == 90)
            {
                damageTimeCounter = 0;
                isDamaged = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
            item.Draw(spriteBatch);
        }
        public string GetStateName()
        {
            return state.GetStateName();
        }
    }
}
