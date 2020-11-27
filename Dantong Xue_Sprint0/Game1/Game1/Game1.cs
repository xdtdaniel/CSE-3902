using Game1.Code;
using Game1.Code.Block;
using Game1.Code.Block.BlockFactory;
using Game1.Code.Enemy;
using Game1.Code.HUD;
using Game1.Code.HUD.Factory;
using Game1.Code.Item;
using Game1.Code.Item.ItemFactory;
using Game1.Code.Item.ItemInterface;
using Game1.Code.LoadFile;
using Game1.Code.Audio;
using Game1.Code.Audio.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Game1.Code.Player;
using Game1.Code.Achievement;
using Game1.Code.Achievement.Factory;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Player.Factory;
using Game1.Code.Player.CollisionHandler;

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
        public List<Tuple<IItemSprite, string>> emptyList;

        private IController mapMouseController;

        private const int preferredWidthUnscaled = 256;
        private const int preferredHeightUnscaled = 232;

        public HUDPanel hudPanel;
        public string selectedItemName;

        private QuitResetController quitResetController;
        public bool paused;
        private bool clockWorking;
        private bool gameStarted;
        public int mapID;
        public int currentMapID;

        private int deathCounter;
        private const int deathCounterLimit = 200;
        public bool goodToRespawn;

        public Camera camera;
        private StartScreen startScreen;
        private AchievementPanel achievementPanel;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //temporary screen size suitable for Sprint 3
            _graphics.PreferredBackBufferWidth = (int)(preferredWidthUnscaled * LoadAll.Instance.scale);
            _graphics.PreferredBackBufferHeight = (int)(preferredHeightUnscaled * LoadAll.Instance.scale);
        }

        protected override void Initialize()
        {

            base.Initialize();

            mapMouseController = new MouseMapController();

            link = new Link();
            playerPanel = new PlayerPanel(this);
            achievementPanel = new AchievementPanel(this);
            hudPanel = new HUDPanel(this);
            selectedItemName = "";
            LoadAll.Instance.GetGameObject(this);
            paused = false;
   
            quitResetController = new QuitResetController();

            deathCounter = deathCounterLimit;
            goodToRespawn = false;

            camera = new Camera(GraphicsDevice.Viewport);
            AudioPlayer.bgm.Play();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            PlayerCharacterFactory.Instance.LoadAllTextures(Content);
            PlayerItemFactory.Instance.LoadAllTextures(Content);
            PlayerAbilityFactory.Instance.LoadAllTextures(Content);
            BlockFactory.Instance.LoadAllTexture(Content);
            EnemyTextureStorage.LoadTextures(Content);
            ItemSpriteFactory.LoadAllTextures(Content);
            HUDFactory.LoadAllHUDTextures(Content);
            AudioFactory.LoadAllAudio(Content);
            AchievementFactory.LoadAll(Content);

            _spriteFont = Content.Load<SpriteFont>("font");

            

            EnemyLoader = new LoadEnemy(LoadAll.Instance.GetCurrentMapID());
            ItemLoader = new LoadItem(LoadAll.Instance.GetCurrentMapID());

            EnemyLoader.LoadAllEnemy();
            ItemLoader.LoadAllItem();

            startScreen = new StartScreen();
            startScreen.LoadTexture(Content);

            EnemyList = EnemyLoader.GetEnemyList();
            inRoomList = ItemLoader.GetItemList();

            LoadAll.Instance.ResetRoomID();
            LoadAll.Instance.LoadRoom();
            movableBlocks = LoadAll.Instance.GetMovableBlocks();


        }

        protected override void Update(GameTime gameTime)
        {
            gameStarted = startScreen.IsGameStarted();
            startScreen.Update();

            paused = camera.PauseGame();
            mapID = PlayerAndItemCollisionHandler.getMapID();

            achievementPanel.Update();

            quitResetController.Update(this);
            if (!paused && gameStarted)
            {
                if (link.isDamaged && link.damageTimeCounter < 20)
                {
                    camera.startShaking = true;
                }
                else
                {
                    camera.startShaking = false;
                }
                playerPanel.PlayerUpdate();

                clockWorking = playerPanel.checkClockActivation();
                currentMapID = LoadAll.Instance.GetCurrentMapID();

                if (clockWorking)
                {
                    for (int i = 0; i < EnemyList.Count; i++)
                    {
                        EnemyList[i].Item1.Freeze();
                    }
                    //                
                }

                DrawAndUpdateEnemy.Instance.UpdateAllEnemy(EnemyList, this);

                mapMouseController.Update(this);

                EnemyLoader.SetCurrentMapID(LoadAll.Instance.GetCurrentMapID());
                EnemyList = EnemyLoader.GetEnemyList();

                emptyList = inRoomList;
                if (EnemyLoader.NoEnemy() || (LoadAll.Instance.GetCurrentMapID()==15))
                {

                    ItemLoader.setRoomID(LoadAll.Instance.GetCurrentMapID());
                    inRoomList = ItemLoader.GetItemList();
                    UpdateAllItem.Instance.UpdateAll(inRoomList);
                }
                else if (!EnemyLoader.NoEnemy() || (LoadAll.Instance.GetCurrentMapID() == 17))
                {
                    emptyList.Clear();
                    UpdateAllItem.Instance.UpdateAll(emptyList);
                }
                movableBlocks = LoadAll.Instance.GetMovableBlocks();
                LoadAll.Instance.SetEnemyStatus(EnemyLoader.NoEnemy());
              
            }
 
            hudPanel.HUDUpdate();
            
            camera.UpdateCamera(GraphicsDevice.Viewport);

            

            if (link.isDead)
            {
                deathCounter--;
                EnemyList.Clear();
                AudioPlayer.bgm.Stop();

                if (deathCounter <= 0 && goodToRespawn)
                {
                    

                    link = new Link();
                    playerPanel = new PlayerPanel(this);
                    hudPanel = new HUDPanel(this);
                    selectedItemName = "";
                    LoadAll.Instance.GetGameObject(this);

                    LoadAll.Instance.ResetMap();
                    EnemyLoader.ResetAllEnemies();
                    ItemLoader.ResetAllItems();
                    LoadAll.Instance.ChangeMapColor(Color.White);
                    AudioPlayer.bgm.Play();

                    deathCounter = deathCounterLimit;
                    goodToRespawn = false;
                }
                
            }


            if (link.state.GetStateName().Equals("WinLink"))
            {
                AudioPlayer.bgm.Stop();
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

            if (link.isDead)
            {
                _spriteBatch.DrawString(_spriteFont, "Press M to Respawn", new Vector2(LoadAll.Instance.startPos.X + 200, LoadAll.Instance.startPos.Y + 200), Color.White);

            }

            DrawAllItem.Instance.DrawAll(inRoomList, _spriteBatch);
            playerPanel.PlayerDraw();

            // HUD
            hudPanel.HUDDraw();

            achievementPanel.Draw();


            if (!gameStarted)
            {
                startScreen.Draw(_spriteBatch, (int)(preferredWidthUnscaled * LoadAll.Instance.scale), (int)(preferredHeightUnscaled * LoadAll.Instance.scale));
            }

            GraphicsDevice.Clear(Color.CornflowerBlue);


            _spriteBatch.End();
        }
    }
}
