using Game1.Code.Block;
using Game1.Code.Block.BlockFactory;
using Game1.Code.Enemy;
using Game1.Code.Item;
using Game1.Code.Item.ItemFactory;
using Game1.Code.Item.ItemInterface;
using Game1.Code.LoadFile;
using Game1.Player.PlayerCharacter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public SpriteBatch _spriteBatch;
        public SpriteFont _spriteFont;
#pragma warning restore CA2213 // Disposable fields should be disposed


        public IItemSprite item; 

        public Link link;
        public PlayerPanel playerPanel;

        public List<IBlock> movableBlocks;

        public LoadEnemy EnemyLoader;
        public List<Tuple<IEnemy, string>> EnemyList;

        public LoadItem ItemLoader;
        public List<Tuple<IItemSprite, string>> inRoomList;
        public List<Tuple<IItemSprite, string>> notInRoomList;


        private IController mapMouseController;

        //Testing controller for sprint 3
        // private MouseEnemyController enemyController;

        private QuitResetController quitResetController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //temporary screen size suitable for Sprint 3
            _graphics.PreferredBackBufferWidth = (int)(256 * LoadAll.Instance.scale);
            _graphics.PreferredBackBufferHeight = (int)(176 * LoadAll.Instance.scale);
        }

        protected override void Initialize()
        {

            base.Initialize();

            mapMouseController = new MouseMapController();

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
            movableBlocks = LoadAll.Instance.GetMovableBlocks();

            EnemyLoader = new LoadEnemy(LoadAll.Instance.GetCurrentMapID());
            ItemLoader = new LoadItem(LoadAll.Instance.GetCurrentMapID());

            EnemyLoader.LoadAllEnemy();
            ItemLoader.LoadAllItem();

            EnemyList = EnemyLoader.GetEnemyList();

            inRoomList = ItemLoader.GetItemList();
            

        }

        protected override void Update(GameTime gameTime)
        {    
            mapMouseController.Update(this);
         
            EnemyList = EnemyLoader.GetEnemyList();
            inRoomList = ItemLoader.GetItemList();              

            DrawAndUpdateEnemy.Instance.UpdateAllEnemy(EnemyList, _spriteBatch, this);
            UpdateAllItem.Instance.UpdateAll(inRoomList);       

            quitResetController.Update(this);
            playerPanel = new PlayerPanel(this);
            playerPanel.PlayerUpdate();

            movableBlocks = LoadAll.Instance.GetMovableBlocks();
            LoadAll.Instance.SetEnemyStatus(EnemyLoader.NoEnemy());

            base.Update(gameTime);

        }


        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Begin();

            DrawMap.Instance.DrawCurrMap(_spriteBatch, LoadAll.Instance.GetMapBlocksToDraw());
            DrawMap.Instance.DrawMovableBlocks(_spriteBatch, movableBlocks);
            DrawMap.Instance.DrawText(_spriteBatch, "EASTMOST PENNINSULA\n          IS THE SECRET", _spriteFont);

            DrawAndUpdateEnemy.Instance.DrawAllEnemy(EnemyList, _spriteBatch);

            DrawAllItem.Instance.DrawAll(inRoomList,_spriteBatch); 
            playerPanel.PlayerDraw();

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.End();
        }
    }
}
