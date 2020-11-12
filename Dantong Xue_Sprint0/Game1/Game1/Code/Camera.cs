using Game1.Code.LoadFile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Game1.Code
{
    public class Camera
    {
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; protected set; }
        public Rectangle VisibleArea { get; protected set; }
        public Matrix Transform { get; protected set; }

        private bool moving = false;
        private int direction;

        private float speed = (float)16/3 * (int)LoadAll.Instance.scale;

        private int scale = (int)LoadAll.Instance.scale;

        int moveTimer = 0;

        double HorizontalMoveTime;
        double VerticalMoveTime;


        private KeyboardState oldState;
        private KeyboardState newState;
        private bool paused;


        public Camera(Viewport viewport)
        {
            Bounds = viewport.Bounds;
            //Position = Vector2.Zero;
            Position = new Vector2(384,348);
            HorizontalMoveTime = 256.0 / speed * scale;
            VerticalMoveTime = 176.0 / speed * scale;
            paused = false;
        }

        
        private void UpdateVisibleArea()
        {
            var inverseViewMatrix = Matrix.Invert(Transform);

            var tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            var tr = Vector2.Transform(new Vector2(Bounds.X, 0), inverseViewMatrix);
            var bl = Vector2.Transform(new Vector2(0, Bounds.Y), inverseViewMatrix);
            var br = Vector2.Transform(new Vector2(Bounds.Width, Bounds.Height), inverseViewMatrix);

            var min = new Vector2(
                MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
                MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
            var max = new Vector2(
                MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
                MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));
            VisibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }

        private void UpdateMatrix()
        {
            Transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                    Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));
            UpdateVisibleArea();
        }

        public void MoveCamera(Vector2 movePosition)
        {
            Vector2 newPosition = Position + movePosition;
            Position = newPosition;
        }

        public void UpdateCamera(Viewport bounds)
        {
            Bounds = bounds.Bounds;
            UpdateMatrix();

            UpdateMovingState("");          

            if (moving) {
                if (direction == 1 || direction == 3) {
                    if (moveTimer < HorizontalMoveTime)
                    {
                        UpdateLocation();
                        moveTimer++;
                    }
                    else 
                    {
                        moveTimer = 0;
                        moving = false;
                    }
                } else if (direction == 0 || direction == 2) {
                    if (moveTimer < VerticalMoveTime)
                    {
                        UpdateLocation();
                        moveTimer++;
                    }
                    else 
                    {
                        moveTimer = 0;
                        moving = false;
                    }
                }
            }


        }

        public void UpdateMovingState(string movingDirection) {
            if ((Keyboard.GetState().IsKeyDown(Keys.Up) && !moving) || movingDirection == "up")
            {
                moving = true;
                direction = 0;
            }

            if ((Keyboard.GetState().IsKeyDown(Keys.Down) && !moving) || movingDirection == "down")
            {
                moving = true;
                direction = 2;
            }

            if ((Keyboard.GetState().IsKeyDown(Keys.Left) && !moving) || movingDirection == "left")
            {
                moving = true;
                direction = 3;
            }

            if ((Keyboard.GetState().IsKeyDown(Keys.Right) && !moving) || movingDirection == "right")
            {
                moving = true;
                direction = 1;
            }
        }

        private void UpdateLocation() {
            Vector2 cameraMovement = Vector2.Zero;

            if (direction == 0)
            {
                cameraMovement.Y = -speed;
            }

            if (direction == 2)
            {
                cameraMovement.Y = speed;
            }

            if (direction == 3)
            {
                cameraMovement.X = -speed;
            }

            if (direction == 1)
            {
                cameraMovement.X = speed;
            }

            MoveCamera(cameraMovement);
        }

        public bool PauseGame()
        {
            newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.P) && !oldState.IsKeyDown(Keys.P))
            {
                
                paused = !paused;
                if (paused)
                {
                    UpdateMovingState("up");
                }
                else
                {
                    UpdateMovingState("down");
                }
            }

            oldState = newState;


            return paused;
        }
    }
}
