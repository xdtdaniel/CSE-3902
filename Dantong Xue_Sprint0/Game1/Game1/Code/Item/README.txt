Item include 5 parts.

ItemFacotory, IItemInterface, ItemSprite, ItemKeyboardController,  ItemLists.
ItemFactory contain all the required items in item part and it use "instance" to call all the createItem() methods in ItemSprite folder. 
All methods inside ItemSprite inherited from IItemSprite interface, each method have a Draw() method to draw the item, and Update()  method for some items(Heart, Fairy,  
Rubee, Triforce).
IItemInterfaace contain 2 methods Draw() and Update().
ItemKeyboardController is used to get user's keyboardinput for item control.  "U" for previous item, "I" for next item in item list. It include 2 methods, Update() to update  
current item with user input, Draw is used to call Draw() method of  each item.
ItemList is a class to generate a list of items by call itemList.Add(ItemFactory.ItemSpriteFactory.Instance."CreateItem()";
ItemList has an  static int  index  used to iterate all  items  in the list. It  has Draw(),  Update(), MovePrev(), MoveNext, all use index to distinct items.


Here is required code in Game1 class:

public class Game1 : Game
    {
        public IItemSprite item; 
        private ItemKeyboardController itemKeyboardController;

        protected override void Initialize()
        {
            itemKeyboardController = new ItemKeyboardController();
            playerCommand = new PlayerCommand(spriteBatch, this);
        }

        protected override void LoadContent()
        {
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            
        }
        protected override void Update(GameTime gameTime)
        {

            itemKeyboardController.Update(this);

        }
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            itemKeyboardController.Draw(_spriteBatch, 400, 200);
            _spriteBatch.End();

        }

    }
}
