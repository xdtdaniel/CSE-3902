using Game1.Code;
using Game1.Code.Block;
using Game1.Code.Block.BlockFactory;
using Game1.Code.Enemy;
using Game1.Code.HUD;
using Game1.Code.HUD.Factory;
using Game1.Code.HUD.Sprite;
using Game1.Code.Item;
using Game1.Code.Item.ItemFactory;
using Game1.Code.Item.ItemInterface;
using Game1.Code.Item.ItemSprite;
using Game1.Code.ItemSelection.ItemSelectionFactory;
using Game1.Code.LoadFile;
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
        public GraphicsDeviceManager _graphics;
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

        //test for  sprint 4 hud display
        HUDPanel hudPanel;

        private QuitResetController quitResetController;

        public Camera camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //temporary screen size suitable for Sprint 3
            _graphics.PreferredBackBufferWidth = (int)(256 * LoadAll.Instance.scale);
            _graphics.PreferredBackBufferHeight = (int)(232 * LoadAll.Instance.scale);
        }

        protected override void Initialize()
        {

            base.Initialize();

            mapMouseController = new MouseMapController();

            link = new Link();
            playerPanel = new PlayerPanel(this);
            hudPanel = new HUDPanel(this);
            LoadAll.Instance.GetGameObject(this);

            quitResetController = new QuitResetController();

            camera = new Camera(GraphicsDevice.Viewport);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            PlayerCharacterFactory.Instance.LoadAllTextures(Content);
            PlayerItemFactory.Instance.LoadAllTextures(Content);
            BlockFactory.Instance.LoadAllTexture(Content);
            EnemyTextureStorage.LoadTextures(Content);
            ItemSpriteFactory.LoadAllTextures(Content);
            HUDFactory.LoadAllHUDTextures(Content);
            ItemSelectionFactory.LoadAllTextures(Content);

            _spriteFont = Content.Load<SpriteFont>("font");
          
            LoadAll.Instance.LoadRoom();
            movableBlocks = LoadAll.Instance.GetMovableBlocks();

            EnemyLoader = new LoadEnemy(LoadAll.Instance.GetCurrentMapID());
            ItemLoader = new LoadItem(LoadAll.Instance.GetCurrentMapID());

            EnemyLoader.LoadAllEnemy();

            ItemLoader.LoadAllItem();

            EnemyList = EnemyLoader.GetEnemyList();

            inRoomList = ItemLoader.GetItemList();

            //TEST FOR HUD

            //item selection  
            
        }

        protected override void Update(GameTime gameTime)
        {    
            mapMouseController.Update(this);

            EnemyLoader.SetCurrentMapID(LoadAll.Instance.GetCurrentMapID());
            EnemyList = EnemyLoader.GetEnemyList();
            inRoomList = ItemLoader.GetItemList();              

            DrawAndUpdateEnemy.Instance.UpdateAllEnemy(EnemyList, _spriteBatch, this);
            UpdateAllItem.Instance.UpdateAll(inRoomList);       

            quitResetController.Update(this);
            playerPanel = new PlayerPanel(this);
            playerPanel.PlayerUpdate();

            movableBlocks = LoadAll.Instance.GetMovableBlocks();
            LoadAll.Instance.SetEnemyStatus(EnemyLoader.NoEnemy());

            //TEST FOR HUD
            hudPanel.HUDUpdate();
            //item selection

            camera.UpdateCamera(GraphicsDevice.Viewport);
            
            base.Update(gameTime);

        }


        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Begin(transformMatrix: camera.Transform);

            DrawMap.Instance.DrawCurrMap(_spriteBatch, LoadAll.Instance.GetMapBlocksToDraw()[0]);
            DrawMap.Instance.DrawCurrMap(_spriteBatch, LoadAll.Instance.GetMapBlocksToDraw()[1]);
            DrawMap.Instance.DrawMovableBlocks(_spriteBatch, movableBlocks);
            DrawMap.Instance.DrawText(_spriteBatch, "EASTMOST PENNINSULA\n          IS THE SECRET", _spriteFont);

            DrawAndUpdateEnemy.Instance.DrawAllEnemy(EnemyList, _spriteBatch);
            if (EnemyLoader.GetCurrentMapID() == 11)
            {
                _spriteBatch.DrawString(_spriteFont, "Test", new Vector2(400, 200), Color.Red);
                DrawMap.Instance.DrawCurrMap(_spriteBatch, EnemyLoader.LoadRoom11Walls());
            }

            DrawAllItem.Instance.DrawAll(inRoomList, _spriteBatch);
            playerPanel.PlayerDraw();
            // item  selection
            // todo

            // HUD
            // must be the last to draw
            hudPanel.HUDDraw();

            string x = "hud x: " + hudPanel.x.ToString();


            string y = "hud y: " + hudPanel.y.ToString();


            // for hud debugging
            _spriteBatch.DrawString(_spriteFont, x, new Vector2(link.x - 150, link.y - 25), Color.Black);
            _spriteBatch.DrawString(_spriteFont, y, new Vector2(link.x - 150, link.y), Color.Black);
            //

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.End();
        }
    }
}
