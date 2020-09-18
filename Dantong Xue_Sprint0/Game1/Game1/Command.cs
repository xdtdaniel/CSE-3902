using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public class Command
    {
        private static int count;
        
        public enum Actions { non_moving_still, moving_still, non_moving_animated, moving_animated, text, exit, none };

        private static Actions prev;
        private static Actions curr;

        public Command()
        {
            prev = Actions.none;
            curr = Actions.non_moving_still;
        }

        public Actions getPrev()
        {
            return prev;
        }

        public Actions getCurr()
        {
            return curr;
        }

        public void Execute(Actions a, Game1 g, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            System.Diagnostics.Debug.WriteLine(a);
            if (prev == Actions.none)
            {
                prev = a;
                if (a != Actions.text && a != Actions.none)
                {
                    curr = a;
                }

                switch (a)
                {
                    case Actions.non_moving_animated:
                        DrawNonmovingAnimated(g, spriteBatch);
                        break;
                    case Actions.exit:
                        g.Exit();
                        break;
                    case Actions.non_moving_still:
                        DrawNonmovingStill(g, spriteBatch);
                        break;
                    case Actions.moving_animated:
                        DrawMovingAnimated(g, spriteBatch);
                        break;
                    case Actions.moving_still:
                        DrawMovingStill(g, spriteBatch);
                        break;
                    case Actions.text:
                        DrawText(g, spriteBatch);
                        break;
                }

                prev = Actions.none;
            }

            spriteBatch.End();
        }

        private void DrawMovingAnimated(Game1 g, SpriteBatch spriteBatch)
        {
            g.GraphicsDevice.Clear(Color.CornflowerBlue);
            /*
                if (count >= 400)
                {
                    count = 0;
                }
            
            count++;
            */
            g.movingAnimatedLuigi.Draw(spriteBatch, new Vector2(200, 200));
            g.movingAnimatedLuigi.Update();
        }

        private void DrawNonmovingAnimated(Game1 g, SpriteBatch spriteBatch)
        {
            g.GraphicsDevice.Clear(Color.CornflowerBlue);
            g.animatedLuigi.Draw(spriteBatch, new Vector2(200, 200));
            g.animatedLuigi.Update();
        }

        private void DrawNonmovingStill(Game1 g, SpriteBatch spriteBatch)
        {
            g.GraphicsDevice.Clear(Color.CornflowerBlue);
            g.stillLuigi.Draw(spriteBatch, new Vector2(200, 200));
        }

        private void DrawMovingStill(Game1 g, SpriteBatch spriteBatch)
        {
            g.GraphicsDevice.Clear(Color.CornflowerBlue);
            g.movingLuigi.Draw(spriteBatch, new Vector2(200, 200));
            g.movingLuigi.Update();
        }

        private void DrawText(Game1 g, SpriteBatch spriteBatch)
        {
            
            g.textToDraw.Draw(spriteBatch, new Vector2(50, 350));
        }
    }
}
