using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Game1.Code.Item.ItemFactory;
using Game1.Code.Item.ItemInterface;
using Game1.Code.Item.ItemSprite;

namespace Game1
{
    public class Command
    {
        private static int count;
        
        public enum Actions { non_moving_still, moving_still, non_moving_animated, moving_animated, text, exit, none };
        public enum ItemSelect { arrow, bomb, boomerang, bow, clock, compass,fairy,heart,heartcontainer,key,map,ruby,triforce};
        private static ItemSelect current_item; 

        private static Actions prev;
        private static Actions curr;


        public Command()
        {
            prev = Actions.none;
            curr = Actions.non_moving_still;

            current_item = ItemSelect.arrow;
        }

        public Actions getPrev()
        {
            return prev;
        }

        public Actions getCurr()
        {
            return curr;
        }

        public ItemSelect getState() { 
            return current_item;
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
        public void DisplayItem(ItemSelect i, Game1 g) {
            System.Diagnostics.Debug.WriteLine(i);
            //  initial should display item arrow
            if (current_item == ItemSelect.arrow)
            {
                 switch (current_item) // change based on input U or I
                {
                    case ItemSelect.bomb:
                        ItemSpriteFactory.Instance.CreateBomb();
                        break;
                    case ItemSelect.boomerang:
                        ItemSpriteFactory.Instance.CreateBoomerang();
                        break;
                    case ItemSelect.bow:
                        ItemSpriteFactory.Instance.CreateBow();
                        break;
                    case ItemSelect.clock:
                        ItemSpriteFactory.Instance.CreateClock();
                        break;
                    case ItemSelect.compass:
                        ItemSpriteFactory.Instance.CreateCompass();
                        break;
                    case ItemSelect.fairy:
                        ItemSpriteFactory.Instance.CreateFairy();
                        break;
                    case ItemSelect.heart:
                        ItemSpriteFactory.Instance.CreateHeart();
                        break;
                    case ItemSelect.heartcontainer:
                        ItemSpriteFactory.Instance.CreateHeartContainer();
                        break;
                    case ItemSelect.key:
                        ItemSpriteFactory.Instance.CreateKey();
                        break;
                    case ItemSelect.map:
                        ItemSpriteFactory.Instance.CreateMap();
                        break;
                    case ItemSelect.ruby:
                        ItemSpriteFactory.Instance.CreateRuby();
                        break;
                    case ItemSelect.triforce:
                        ItemSpriteFactory.Instance.CreateTriforce();
                        break;
                }

                current_item = ItemSelect.arrow;
            }

         }

        private void DrawMovingAnimated(Game1 g, SpriteBatch spriteBatch)
        {
            g.GraphicsDevice.Clear(Color.CornflowerBlue);
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
