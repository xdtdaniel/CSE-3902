Player has 6 folders and 1 concrete class:
    CollisionHandler, Control, Factory, Interface, PlayerCharacter, PlayerItem and PlayerPanel.cs.
    
CollisionHandler: Files that generate collision responses when 2 objects are collided.

Control: An interface and a concrete class to control Link sprite.

Factory: PlayerCharacterFactory.cs produces character related sprites and PlayerItemFactory.cs produces item related sprites. 

Interface: IPlayerItemDrawer.cs: Interface for item drawer. IPlayerLinkState.cs: Interface for Link state. IPlayerSprite.cs: Interface for player sprite. 

PlayerCharacter: Contains LinkSprite and LinkState folders and Link.cs. Classes in LinkSprite provide Draw() method for classes in LinkState to draw the according sprites on screen. Classes in LinkState implement different states of Link using state pattern. Link.cs is the main class of Player.

PlayerItem: Contains PlayerItemSprite and PlayerItemDrawer folders and PlayerItem.cs. Classes in PlayerItemSprite provide Draw() method for classes in PlayerItemDrawer to draw the according sprites on screen. Classes in PlayerItemDrawer implement different states of item using state pattern. PlayerItem.cs is the instance represents the item that is being used by Link. 

PlayerCommand.cs: Integrate all the commands for Player so only a PlayerCommand and a Link instances in main game class are needed. 



/* required in Game1.cs */

public class Game1 : Game
    {
        public Link link;
        private PlayerPanel playerPanel;

        protected override void Initialize()
        {
            link = new Link();
            playerPanel = new PlayerPanel(this);
        }

        protected override void LoadContent()
        {
            PlayerCharacterFactory.Instance.LoadAllTextures(Content);
            PlayerItemFactory.Instance.LoadAllTextures(Content);
        }
        protected override void Update(GameTime gameTime)
        {
            playerPanel.PlayerUpdate();
        }
        protected override void Draw(GameTime gameTime)
        {
            playerPanel.PlayerDraw();
        }
    }
}
