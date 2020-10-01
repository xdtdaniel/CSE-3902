using Game1.Code.Block;
using Game1.Code.Block.BlockFactory;
using Game1.Code.Item;
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

        public ISprite animatedLuigi;
        public SpriteFont font;
        public ISprite stillLuigi;
        public ISprite textToDraw;
        public ISprite movingLuigi;
        public ISprite movingAnimatedLuigi;
        public IItemSprite item; 
        public Command command;

        public Link link;
        private PlayerCommand playerCommand;

        private List<object> controllerList;

        private IController blockKeyboardController;
        private IController mouseController;
        private ItemKeyboardController itemKeyboardController;

        private EnemyKeyboardController enemyKeyboradController;
        private QuitResetController quitResetController;

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

            enemyKeyboradController = new EnemyKeyboardController();
            itemKeyboardController = new ItemKeyboardController();

            link = new Link();
            playerCommand = new PlayerCommand(_spriteBatch, this);
            quitResetController = new QuitResetController();
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


            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*
             *  Sprint 0 Code
             * 
                animatedLuigi = new NonMovingAnimatedSprite(imgMoving, 8, 8);
                stillLuigi = new NonMovingNonAnimatedSprite(imgStand);
                movingLuigi = new MovingNonAnimatedSprite(imgStand, 480, new Vector2(0, 0), new Vector2(480, 480));
                movingAnimatedLuigi = new MovingAnimatedSprite(imgMoving, 8, 8, 200, new Vector2(480, 480), new Vector2(0, 0));
            */


            // textToDraw = new TextSprite(font, "Credit\nProgram Made by: Dantong Xue\nSprites from: http://www.mariouniverse.com/sprites-nes-smb/");

            PlayerCharacterFactory.Instance.LoadAllTextures(Content);
            PlayerItemFactory.Instance.LoadAllTextures(Content);
            BlockFactory.Instance.LoadAllTexture(Content);
            EnemyTextureStorage.LoadTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);     
        }

        protected override void Update(GameTime gameTime)
        {
            foreach(IController controller in controllerList)
            {
                controller.Update(this.GraphicsDevice, this._spriteBatch, this);
            }

            enemyKeyboradController.Update(this);
            itemKeyboardController.Update(this);
            quitResetController.Update(this);

            // Keep executing the previous event if no event changes happen
            // command.Execute(command.getCurr(), this, _spriteBatch);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            // command.Execute(Command.Actions.text, this, _spriteBatch);
            base.Draw(gameTime);

            //enemyKeyboradController.Draw(_spriteBatch);
            itemKeyboardController.Draw(_spriteBatch, 400, 200);
        }
    }
}
