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
        public SpriteBatch _spriteBatch;
        public SpriteFont _spriteFont;
#pragma warning restore CA2213 // Disposable fields should be disposed


        public IItemSprite item; 

        public Link link;
        public PlayerPanel playerPanel;

        private List<IBlock> movableBlocks;

        private LoadEnemy EnemyLoader;
        public List<Tuple<IEnemy, string>> EnemyList;
        public List<Tuple<IItemSprite, string>> inRoomList;

        private IController mapMouseController;

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

            mapMouseController = new MouseMapController();

            enemyController = new MouseEnemyController();

            link = new Link();
            playerPanel = new PlayerPanel(this);

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
          
            LoadAll.Instance.LoadRoom();
            LoadAll.Instance.LoadRoomItem();
            movableBlocks = LoadMap.Instance.GetMovableBlocks();

            EnemyLoader = new LoadEnemy(LoadAll.Instance.GetCurrentMapID());
            EnemyLoader.LoadAllEnemy();
            EnemyList = EnemyLoader.GetEnemyList();
            inRoomList = LoadItem.Instance.GetItemList();
        }

        protected override void Update(GameTime gameTime)
        {    
            mapMouseController.Update(this);

            enemyController.Update(EnemyLoader);
            EnemyList = EnemyLoader.GetEnemyList();
            

            DrawAndUpdateEnemy.Instance.UpdateAllEnemy(EnemyList, _spriteBatch);
            quitResetController.Update(this);
            playerPanel.PlayerUpdate();

            movableBlocks = LoadMap.Instance.GetMovableBlocks();

            UpdateAllItem.Instance.UpdateAll(inRoomList);
            base.Update(gameTime);

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
            playerPanel.PlayerDraw();

            _spriteBatch.DrawString(_spriteFont, EnemyLoader.NoEnemy().ToString(), new Vector2(400, 200), Color.Red);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.End();
        }
    }
}
