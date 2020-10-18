using Game1.Code.Block;
using Game1.Code.Block.BlockFactory;
using Game1.Code.Enemy;
using Game1.Code.Item;
using Game1.Code.Item.ItemFactory;
using Game1.Code.Item.ItemInterface;
using Game1.Code.Item.ItemSprite;
using Game1.Code.LoadFile;
using Game1.Code.Player;
using Game1.Enemy;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game1
{
    public class Game1 : Game
    {

#pragma warning disable CA2213 // Disposable fields should be disposed
        private GraphicsDeviceManager _graphics;
#pragma warning restore CA2213 // Disposable fields should be disposed

#pragma warning disable CA2213 // Disposable fields should be disposed
        private SpriteBatch _spriteBatch;
        public SpriteFont _spriteFont;
#pragma warning restore CA2213 // Disposable fields should be disposed


        public IItemSprite item; 

        public Link link;
        public PlayerCommand playerCommand;

        private List<object> controllerList;

        private List<Tuple<IEnemy, string>> EnemyList;

        private IController blockKeyboardController;
        private ItemKeyboardController itemKeyboardController;
        public PlayerKeyboardController playerKeyboardController;

        private QuitResetController quitResetController;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();

            controllerList = new List<object>();

            itemKeyboardController = new ItemKeyboardController();
            playerKeyboardController = new PlayerKeyboardController();


            link = new Link();
            playerCommand = new PlayerCommand(_spriteBatch, this);

            quitResetController = new QuitResetController();


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            PlayerCharacterFactory.Instance.LoadAllTextures(Content);
            PlayerItemFactory.Instance.LoadAllTextures(Content);
            BlockFactory.Instance.LoadAllTexture(Content);
            EnemyTextureStorage.LoadTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);

            _spriteFont = Content.Load<SpriteFont>("font");

            EnemyList = LoadEnemy.Instance.GetEnemyList();

            LoadAll.Instance.LoadRoom();
        }

        protected override void Update(GameTime gameTime)
        {
            foreach(IController controller in controllerList)
            {
                controller.Update(this.GraphicsDevice, this._spriteBatch, this);
            }

            DrawAndUpdateEnemy.Instance.UpdateAllEnemy(EnemyList, _spriteBatch);
            itemKeyboardController.Update(this);
            playerKeyboardController.Update();
            quitResetController.Update(this);
            playerCommand.PlayerUpdate();

            base.Update(gameTime);

            // for collision test
            // playerAquamentusCollisionHandler.HandleCollision(link, enemyKeyboradController.EnemyCollection.EnemyList[0], playerKeyboardController.Direction(), playerKeyboardController.side);
        }


        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Begin();
            
            LoadItem.Instance.LoadRoomItem(_spriteBatch);
            

            DrawMap.Instance.DrawCurrMap(_spriteBatch, LoadAll.Instance.GetMapBlocksToDraw());

            DrawAndUpdateEnemy.Instance.DrawAllEnemy(EnemyList, _spriteBatch);
            // enemyKeyboradController.Draw(_spriteBatch);
            playerCommand.PlayerDraw();

            GraphicsDevice.Clear(Color.CornflowerBlue);

            //itemKeyboardController.Draw(_spriteBatch, 400, 200);
            _spriteBatch.End();
        }
    }
}
