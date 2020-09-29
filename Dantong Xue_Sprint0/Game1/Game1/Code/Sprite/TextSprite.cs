using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public class TextSprite : ISprite
    {

        private SpriteFont Font { get; set; }
        private String Str { get; set; }

        public TextSprite(SpriteFont font, String str)
        {
            this.Font = font;
            this.Str = str;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.DrawString(this.Font, this.Str, location, Color.Black);
        }

        public void Update()
        {
            // nothing to do for static sprites
        }

        public void SetPath(Vector2 from, Vector2 to)
        {
            // nonmoving, nothing here
        }
    }
}
