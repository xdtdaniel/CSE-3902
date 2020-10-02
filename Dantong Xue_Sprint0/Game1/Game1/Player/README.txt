/* required in Game class */

public class Game1 : Game
    {
        public Link link;
        private PlayerCommand playerCommand;

        protected override void Initialize()
        {
            link = new Link();
            playerCommand = new PlayerCommand(spriteBatch, this);
        }

        protected override void LoadContent()
        {
            PlayerCharacterFactory.Instance.LoadAllTextures(Content);
            PlayerItemFactory.Instance.LoadAllTextures(Content);
        }
        protected override void Update(GameTime gameTime)
        {
            playerCommand.PlayerUpdate();
        }
        protected override void Draw(GameTime gameTime)
        {
            playerCommand.PlayerDraw();
        }
    }
}
