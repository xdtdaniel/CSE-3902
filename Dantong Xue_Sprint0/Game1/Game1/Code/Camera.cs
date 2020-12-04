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
    public static class Camera
    {
        public static Vector2 Position = new Vector2(384, 348);
        public static Rectangle Bounds;
        public static Rectangle VisibleArea;
        public static Matrix Transform;

        private static bool moving = false;
        private static int direction;
        private static  float defaultWidth = 256;
        private static  float defaultHeight = 176;

        private static float speed = (float)16/3 * (int)LoadAll.Instance.scale;

        private static int scale = (int)LoadAll.Instance.scale;

        static int moveTimer = 0;

        static double HorizontalMoveTime = defaultWidth / speed * scale;
        static double VerticalMoveTime = defaultHeight / speed* scale;

        private static int shakeCameraMin = -1 * scale;
        private static int shakeCameraMax = 1 * scale;
        private static int shakeCameraOffset_x = 0;
        private static int shakeCameraOffset_y = 0;
        public static bool shaking = false;
        private static int shakeCurrentFrame = 0;
        private static int shakeTotalFrame = 15;
        private static int shakeMagnitude = 0;

        private static KeyboardState oldState;
        private static KeyboardState newState;
        private static bool paused = false;
        public static int pausedType = -1; // -1 for not paused, 0 for paused, 1 for openning inventory, 2 for openning ability tree



        
        private static void UpdateVisibleArea(Viewport viewport)
        {
            Bounds = viewport.Bounds;
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

        private static void UpdateMatrix(Viewport viewport)
        {
            Bounds = viewport.Bounds;
            Transform = Matrix.CreateTranslation(new Vector3(-Position.X + shakeCameraOffset_x, -Position.Y + shakeCameraOffset_y, 0)) *
                    Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));
            UpdateVisibleArea(viewport);
        }

        public static void MoveCamera(Vector2 movePosition)
        {
            Vector2 newPosition = Position + movePosition;
            Position = newPosition;
        }
        public static void ShakeCamera(int magnitude)
        {
            shakeMagnitude = magnitude;
            shaking = true;
        }

        public static void UpdateCamera(Viewport viewport)
        {
            Bounds = viewport.Bounds;

            UpdateMatrix(viewport);

            UpdateMovingState("");

            Reset();

            if (shakeCurrentFrame < shakeTotalFrame && shaking)
            {
                Random rd = new Random();
                shakeCameraOffset_x = rd.Next(shakeCameraMin * shakeMagnitude, shakeCameraMax * shakeMagnitude);
                shakeCameraOffset_y = rd.Next(shakeCameraMin * shakeMagnitude, shakeCameraMax * shakeMagnitude);
                shakeCurrentFrame++;
            }
            else
            {
                shakeCameraOffset_x = 0;
                shakeCameraOffset_y = 0;
                shakeCurrentFrame = 0;
                shaking = false;
            }


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

        public static void UpdateMovingState(string movingDirection) {
            if (movingDirection == "up")
            {
                moving = true;
                direction = 0;
            }

            if (movingDirection == "down")
            {
                moving = true;
                direction = 2;
            }

            if (movingDirection == "left")
            {
                moving = true;
                direction = 3;
            }

            if (movingDirection == "right")
            {
                moving = true;
                direction = 1;
            }
        }

        private static void UpdateLocation() {
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

        public static bool PauseGame()
        {
            newState = Keyboard.GetState();


            if (!moving)
            {
                if (newState.IsKeyDown(Keys.P) && !oldState.IsKeyDown(Keys.P))
                {
                    paused = true;
                    if (paused && pausedType == -1)
                    {
                        pausedType = 1;
                        UpdateMovingState("up");
                    }
                    else if (pausedType == 1)
                    {
                        paused = false;
                        pausedType = -1;
                        UpdateMovingState("down");
                    }
                }
                else if (newState.IsKeyDown(Keys.O) && !oldState.IsKeyDown(Keys.O))
                {
                    paused = true;
                    if (paused && pausedType == -1)
                    {
                        pausedType = 2;
                        UpdateMovingState("down");
                    }
                    else if (pausedType == 2)
                    {
                        paused = false;
                        pausedType = -1;
                        UpdateMovingState("up");
                    }
                }
                //pause crrent screen by press space
                else if (newState.IsKeyDown(Keys.Space) && !oldState.IsKeyDown(Keys.Space))
                {
                    paused = true;
                    if (paused && pausedType == -1)
                    {
                        pausedType = 0;
                    }
                    else if (pausedType == 0)
                    {
                        paused = false;
                        pausedType = -1;
                    }

                }
            }

            oldState = newState;
            return paused;
        }

        public static void Reset() {
            newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.H) && !moving)
            {
                Vector2 newPosition = new Vector2(384, 348);
                Position = newPosition;
            }
        }
    }
}
