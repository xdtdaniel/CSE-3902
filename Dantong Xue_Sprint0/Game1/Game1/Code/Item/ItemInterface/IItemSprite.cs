﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Code.Item.ItemInterface
{
    public interface IItemSprite
    {
        void Draw(SpriteBatch spriteBatch, int x, int y);
    }
}
