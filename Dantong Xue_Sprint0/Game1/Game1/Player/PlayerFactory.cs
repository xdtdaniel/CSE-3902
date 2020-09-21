using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Player;

namespace Sprint_2
{
    class PlayerFactory
    {
        ContentManager content;
        Link link;
        WoodenSword woodenSword;
        SwordBeam swordBeam;
        Arrow arrow;
        Boomerang boomerang;
        Bomb bomb;
        BlueCandle blueCandle;
        BluePotion bluePotion;
        BlueRing blueRing;
        public PlayerFactory(ContentManager Content)
        {
            content = Content;
        }

        public IPlayer GetPlayer(String name)
            {
                switch (name)
                {
                    case "Link":
                        link = new Link(content);
                        return link;
                    case "WoodenSword":
                        woodenSword = new WoodenSword(content);
                        return woodenSword;
                    case "SwordBeam":
                        swordBeam = new SwordBeam(content);
                        return swordBeam;
                    case "Arrow":
                        arrow = new Arrow(content);
                        return arrow;
                    case "Boomerang":
                        boomerang = new Boomerang(content);
                        return boomerang;
                    case "Bomb":
                        bomb = new Bomb(content);
                        return bomb;
                    case "BlueCandle":
                        blueCandle = new BlueCandle(content);
                        return blueCandle;
                    case "BluePotion":
                        bluePotion = new BluePotion(content);
                        return bluePotion;
                    case "BlueRing":
                        blueRing = new BlueRing(content);
                        return blueRing;
                default:
                        throw new NotSupportedException();
                }
            }
        }
    }
