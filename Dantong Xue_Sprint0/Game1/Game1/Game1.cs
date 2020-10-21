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
using System.Diagnostics;

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
        public PlayerPanel playerCommand;

        private List<IBlock> movableBlocks;

        private LoadEnemy EnemyLoader;
        private List<Tuple<IEnemy, string>> EnemyList;
        private List<Tuple<IItemSprite, string>> inRoomList;
        private List<Tuple<IItemSprite, string>> outRoomList;

        private IController mapMouseController;
        //private ItemKeyboardController itemKeyboardController;

        //Testing controller for sprint 3
        private MouseEnemyController enemyController;

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


            //itemKeyboardController = new ItemKeyboardController();

            mapMouseController = new MouseMapController();

            enemyController = new MouseEnemyController();

            link = new Link();
            playerCommand = new PlayerPanel(_spriteBatch, this);

            quitResetController = new QuitResetController();


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            PlayerCharacterFactory.Instance.LoadAllTextures(Content);
            PlayerItemFactory.Instance.LoadAllTextures(Content);
            BlockFactory.Instance.LoadAllTexture(Content);
            EnemyTextureStorage.LoadTextures(Content);
            ItemSpriteFactory.LoadAllTextures(Content);

            _spriteFont = Content.Load<SpriteFont>("font");

            inRoomList = LoadItem.Instance.GetItemList();
            
            LoadAll.Instance.LoadRoom();
            LoadAll.Instance.LoadRoomItem();
            movableBlocks = LoadMap.Instance.GetMovableBlocks();

            EnemyLoader = new LoadEnemy(LoadAll.Instance.GetCurrentMapID());
            EnemyLoader.LoadAllEnemy();
            EnemyList = EnemyLoader.GetEnemyList();
        }

        protected override void Update(GameTime gameTime)
        {    
            mapMouseController.Update(this);

            enemyController.Update(EnemyLoader);

            EnemyList = EnemyLoader.GetEnemyList();

            DrawAndUpdateEnemy.Instance.UpdateAllEnemy(EnemyList, _spriteBatch);
            //itemKeyboardController.Update(this);
            quitResetController.Update(this);
            playerCommand.PlayerUpdate(EnemyList);

            movableBlocks = LoadMap.Instance.GetMovableBlocks();

            UpdateAllItem.Instance.UpdateAll(inRoomList);
            base.Update(gameTime);

            // for collision test
            // playerAquamentusCollisionHandler.HandleCollision(link, enemyKeyboradController.EnemyCollection.EnemyList[0], playerKeyboardController.Direction(), playerKeyboardController.side);
        }


        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Begin();
            
            DrawMap.Instance.DrawCurrMap(_spriteBatch, LoadAll.Instance.GetMapBlocksToDraw());
            DrawMap.Instance.DrawMovableBlocks(_spriteBatch, movableBlocks);

            DrawAndUpdateEnemy.Instance.DrawAllEnemy(EnemyList, _spriteBatch);
            DrawAllItem.Instance.DrawAll(inRoomList, _spriteBatch);
            // enemyKeyboradController.Draw(_spriteBatch);
            playerCommand.PlayerDraw();
        
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //itemKeyboardController.Draw(_spriteBatch, 400, 200);
            _spriteBatch.End();
        }
    }
}
