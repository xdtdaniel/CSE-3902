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
using Game1.Code.LoadFile;
using Game1.Player.PlayerCharacter;
using Game1.Code.Audio;
using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework.Audio;
using Game1.Code.Audio.Sounds;
using Game1.Code.Player;

namespace Game1
{
    public class Game1 : Game
    {

        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public SpriteFont _spriteFont;

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
        public string selectedItemName;

        private QuitResetController quitResetController;
        private bool paused;
        private bool useClock;
        private int mapID;
        private int currentMapID;

        public Camera camera;

        private ISounds BGM;

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
            selectedItemName = "";
            LoadAll.Instance.GetGameObject(this);
            paused = false;
   
            quitResetController = new QuitResetController();

            camera = new Camera(GraphicsDevice.Viewport);
            BGM = new BGM();
            BGM.Play();
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
            AudioFactory.LoadAllAudio(Content);
            
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
            paused = camera.PauseGame();
            mapID = PlayerAndItemCollisionHandler.getMapID();

            quitResetController.Update(this);
            if (!paused)
            {
                useClock = hudPanel.Clock();               
                currentMapID = LoadAll.Instance.GetCurrentMapID();
                if (useClock &&  mapID != currentMapID)
                {
                    useClock = false;
                    //Debug.WriteLine("mapID: " + mapID+"current id:"+currentMapID);
                }

                if (!useClock)
                {                   
                    DrawAndUpdateEnemy.Instance.UpdateAllEnemy(EnemyList, _spriteBatch, this);                  

                }
            

                mapMouseController.Update(this);

                EnemyLoader.SetCurrentMapID(LoadAll.Instance.GetCurrentMapID());
                EnemyList = EnemyLoader.GetEnemyList();
                inRoomList = ItemLoader.GetItemList();

                UpdateAllItem.Instance.UpdateAll(inRoomList);

                playerPanel.PlayerUpdate();

                movableBlocks = LoadAll.Instance.GetMovableBlocks();
                LoadAll.Instance.SetEnemyStatus(EnemyLoader.NoEnemy());
              
            }
 
            //TEST FOR HUD
            hudPanel.HUDUpdate();
            
            camera.UpdateCamera(GraphicsDevice.Viewport);


            if (link.isDead || link.state.GetStateName().Equals("WinLink"))
            {
                BGM.Stop();
            }
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
                DrawMap.Instance.DrawCurrMap(_spriteBatch, EnemyLoader.LoadRoom11Walls());
            }

            DrawAllItem.Instance.DrawAll(inRoomList, _spriteBatch);
            playerPanel.PlayerDraw();

            // HUD
            // must be the last to draw
            hudPanel.HUDDraw();

            string x = "hud x: " + hudPanel.x.ToString();
            string y = "hud y: " + hudPanel.y.ToString();


            // for hud debugging
            _spriteBatch.DrawString(_spriteFont, x, new Vector2(link.x - 150, link.y - 25), Color.Black);
            _spriteBatch.DrawString(_spriteFont, y, new Vector2(link.x - 150, link.y), Color.Black);
            

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.End();
        }
    }
}
