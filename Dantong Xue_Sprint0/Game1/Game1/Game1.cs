using Game1.Code.Block;
using Game1.Code.Block.BlockFactory;
using Game1.Code.Item.ItemFactory;
using Game1.Code.Item.ItemInterface;
using Game1.Code.Item.ItemSprite;
using Game1.Enemy;
using Game1.Player.PlayerCharacter;
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
        private Texture2D arrow;// Zhihan added

        public ISprite animatedLuigi;
        public SpriteFont font;
        public ISprite stillLuigi;
        public ISprite textToDraw;
        public ISprite movingLuigi;
        public ISprite movingAnimatedLuigi;
        public IItemSprite item; // Zhihan added
        public Command command;

        public Link link;
        private PlayerCommand playerCommand;

        private List<object> controllerList;

        private IController blockKeyboardController;
        private IController mouseController;

        //Test code for enemy classes
        public IEnemy enemy;

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
            blockKeyboardController = new BlockKeyboardController();
            
            controllerList.Add(blockKeyboardController);

            link = new Link();
            playerCommand = new PlayerCommand(_spriteBatch, this);

            /*
            //Test code for enemy classes
            enemy = new Goriya();
            */
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            /*
             *  Sprint 0 Code
             * 
                imgMoving = this.Content.Load<Texture2D>("Sprite/walk/final_2");
                imgStand = this.Content.Load<Texture2D>("Sprite/stand");
                imgJump = this.Content.Load<Texture2D>("Sprite/jump");
                font = this.Content.Load<SpriteFont>("font");
            */

            arrow = this.Content.Load<Texture2D>("Sprite/items/arrow_sprite");// Zhihan added

            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*
             *  Sprint 0 Code
             * 
                animatedLuigi = new NonMovingAnimatedSprite(imgMoving, 8, 8);
                stillLuigi = new NonMovingNonAnimatedSprite(imgStand);
                movingLuigi = new MovingNonAnimatedSprite(imgStand, 480, new Vector2(0, 0), new Vector2(480, 480));
                movingAnimatedLuigi = new MovingAnimatedSprite(imgMoving, 8, 8, 200, new Vector2(480, 480), new Vector2(0, 0));
            */

            item = ItemSpriteFactory.Instance.CreateArrow(); //// Zhihan added
            item = new Arrow(arrow);// // Zhihan added

            // textToDraw = new TextSprite(font, "Credit\nProgram Made by: Dantong Xue\nSprites from: http://www.mariouniverse.com/sprites-nes-smb/");

            /*
            //Test code for enemy classes
            EnemyTextureStorage.LoadTextures(Content);
            */

            PlayerCharacterFactory.Instance.LoadAllTextures(Content);
            PlayerItemFactory.Instance.LoadAllTextures(Content);
            BlockFactory.Instance.LoadAllTexture(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach(IController controller in controllerList)
            {
                controller.Update(this.GraphicsDevice, this._spriteBatch, this);
            }

            // Keep executing the previous event if no event changes happen
            // command.Execute(command.getCurr(), this, _spriteBatch);

            base.Update(gameTime);

            /*
            //Test code for enemy classes
            enemy.UpdateEnemy(this);
            */
        }


        protected override void Draw(GameTime gameTime)
        {
            // command.Execute(Command.Actions.text, this, _spriteBatch);
            base.Draw(gameTime);

            /*
            //Test code for enemy classes            
            _spriteBatch.Begin();
            enemy.DrawEnemy(_spriteBatch);
            _spriteBatch.End();
            */

            
        }
    }
}
