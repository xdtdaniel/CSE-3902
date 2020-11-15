using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code
{
    public class StartScreen
    {
        private Texture2D startScreenTexture;
        private bool hasStarted;
        private KeyboardState newState;
        private KeyboardState oldState;

        public StartScreen()
        {
            hasStarted = false;
        }

        public void LoadTexture(ContentManager contentManager)
        {
            startScreenTexture = contentManager.Load<Texture2D>("Sprite/start_menu");
        }

        public void Draw(SpriteBatch currSpriteBatch, int widthScaled, int heightScaled)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, startScreenTexture.Width, startScreenTexture.Height);
            Rectangle destinationRectangle = new Rectangle(0, 0, widthScaled, heightScaled);
            currSpriteBatch.Draw(startScreenTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Enter) && !oldState.IsKeyDown(Keys.Enter))
            {
                hasStarted = true;
            }

            this.oldState = this.newState;
        }

        public bool IsGameStarted()
        {
            return hasStarted;
        }
    }
}
