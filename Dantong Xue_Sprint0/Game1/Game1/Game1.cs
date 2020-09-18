using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D imgStand;
        private Texture2D imgJump;
        private Texture2D imgMoving;

        public ISprite animatedLuigi;
        public SpriteFont font;
        public ISprite stillLuigi;
        public ISprite textToDraw;
        public ISprite movingLuigi;
        public ISprite movingAnimatedLuigi;
        public Command command;

        private List<object> controllerList;
        private IController keyboardController;
        private IController mouseController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            command = new Command();

            controllerList = new List<object>();
            keyboardController = new KeyboardController(this);
            mouseController = new MouseController(this);
            controllerList.Add(keyboardController);
            controllerList.Add(mouseController);

            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            imgMoving = this.Content.Load<Texture2D>("Sprite/walk/final_2");
            imgStand = this.Content.Load<Texture2D>("Sprite/stand");
            imgJump = this.Content.Load<Texture2D>("Sprite/jump");
            font = this.Content.Load<SpriteFont>("font");

            GraphicsDevice.Clear(Color.CornflowerBlue);

            animatedLuigi = new AnimatedSprite(imgMoving, 8, 8);
            stillLuigi = new NonAnimatedSprite(imgStand);
            movingLuigi = new NonAnimatedMoving(imgStand);
            movingAnimatedLuigi = new MovingAnimated(imgMoving, 8, 8);

            textToDraw = new TextSprite(font, "Credit\nProgram Made by: Dantong Xue\nSprites from: http://www.mariouniverse.com/sprites-nes-smb/");
        }

        protected override void Update(GameTime gameTime)
        {
            foreach(IController controller in controllerList)
            {
                controller.Update(this.GraphicsDevice, this._spriteBatch, this);
            }

            // Keep executing the previous event if no event changes happen
            command.Execute(command.getCurr(), this, _spriteBatch);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            command.Execute(Command.Actions.text, this, _spriteBatch);
            base.Draw(gameTime);
        }
    }
}
