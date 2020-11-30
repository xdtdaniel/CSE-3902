using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Code.Item.ItemInterface;
using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.Code.HUD.Factory;
namespace Game1.Code.Item.ItemSprite
{
    class LevelUp 
    {
        SpriteFont font;
        int height;
        int width;
        private int x;
        private int y;
        public LevelUp(int position_x, int position_y)
        {
            font = HUDFactory.LoadLevelUpText();
            x = position_x;
            y = position_y;
            height = 16 * (int)LoadAll.Instance.scale;
            width = 6 * (int)LoadAll.Instance.scale;
        }
        public void Draw(SpriteBatch spriteBatch)
        { 
            spriteBatch.DrawString(font, "LevelUp, Press [O] to select new ability!", new Vector2(x + (int)LoadAll.Instance.startPos.X, y + (int)LoadAll.Instance.startPos.Y), Color.OrangeRed);
        }

        public void Update()
        {

        }

    
    }
}