[Author] Zhihan Li
[Sprint 3 Addition of README]
Two classes are add in Item file, DrawAllItem.cs and UpdateAllItem.cs, it is read the list generate by LoadItem.cs and iterate the list and call Draw and Update method on each item sptire class.

ItemFactory class is changed from sprint 2, now it is only a class to generate Texture2D type picture which it used by each item sprite class.
This change benefit the loadItem.cs which it is easy to pass location to create new item by just create a new IItemSprite type variable. It is easy to maintain
than previous version.


[README from Sprint 2]
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

Code Analysis Result:
2 Warnings
Severity	Code	Description	Project	File	Line	Suppression State
Warning	CA2213	'Game1' contains field '_graphics' that is of IDisposable type 'GraphicsDeviceManager', but it is never disposed. Change the Dispose method on 'Game1' to call Close or Dispose on this field.	Game1	C:\Users\~!\Downloads\CSE-3902-master\CSE-3902-master\Dantong Xue_Sprint0\Game1\Game1\Game1.cs	19	Active
Severity	Code	Description	Project	File	Line	Suppression State
Warning	CA2213	'Game1' contains field '_spriteBatch' that is of IDisposable type 'SpriteBatch', but it is never disposed. Change the Dispose method on 'Game1' to call Close or Dispose on this field.	Game1	C:\Users\~!\Downloads\CSE-3902-master\CSE-3902-master\Dantong Xue_Sprint0\Game1\Game1\Game1.cs	21	Active

Fiexed by suppress in Source: #pragma warning disable CA2213 // Disposable fields should be disposed
Problem Fixed.
