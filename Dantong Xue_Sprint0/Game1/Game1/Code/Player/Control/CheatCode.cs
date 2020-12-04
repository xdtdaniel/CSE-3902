using System.Collections.Generic;
using System.Text;
using Game1.Code.Player.Control.PlayerControlCommand;
using Game1.Code.Player.Interface;
using Microsoft.Xna.Framework.Input;
using Game1.Code.Audio;

namespace Game1.Code.Player.Control
{
    public class CheatCode
    {
        private Game1 game;
        string _stringValue = string.Empty;
        KeyboardState keyState;
        KeyboardState preState;

        public CheatCode(Game1 game)
        {
            this.game = game;
        }

        public void Update(Keys[] pressedKeys)
        {
            bool cheatActive = false;
            preState = keyState;
            keyState = Keyboard.GetState();

            if (pressedKeys.Length > 0)
            {
                if (keyState.IsKeyDown(pressedKeys[pressedKeys.Length - 1]) && preState.IsKeyUp(pressedKeys[pressedKeys.Length - 1]))
                {
                    string keyValue = pressedKeys[pressedKeys.Length - 1].ToString();
                    if (_stringValue.Length == 0)
                    {
                        _stringValue += keyValue;
                    }
                    if (!keyValue.Equals(_stringValue[_stringValue.Length - 1]))
                    {
                        _stringValue += keyValue;
                    }
                }
            }


            // WDDSSDD for adding 10 bombs
            if (_stringValue.Contains("WDDSSDD"))
            {
                game.link.itemList["Bomb"]+=10;
                _stringValue = "";
                cheatActive = true;
            }

            //ADDDAAA for adding 10 arrows
            if (_stringValue.Contains("ADDDAAA"))
            {
                game.link.itemList["Arrow"] += 10;
                _stringValue = "";
                cheatActive = true;
            }

            //WSWSWSAADD for adding 1 heart
            if (_stringValue.Contains("WSWSWSAADD"))
            { 
                game.link.itemList["Heart"] ++;
                _stringValue = "";
                cheatActive = true;
            }

            //AADDNNW for adding 1 key
            if (_stringValue.Contains("AADDNNW"))
            {
                game.link.itemList["Key"]++;
                _stringValue = "";
                cheatActive = true;
            }

            //NNDWAAWD for adding 1 key
            if (_stringValue.Contains("NNDWAAWD"))
            {
                game.link.itemList["Ruby"]++;
                _stringValue = "";
                cheatActive = true;
            }

            //WWSSAADDBABA for max damage for link
            if (_stringValue.Contains("WWSSAADDBABA"))
            {
                game.link.basicAttackDamage = 999;
                _stringValue = "";
                cheatActive = true;
            }
            
                        //SSWWSSDD for adding 10 exp
            if (_stringValue.Contains("SSWWSSDD"))
            {
                game.link.exp+=10;
                _stringValue = "";
                cheatActive = true;
            }

            //WWDASSAD for adding 100 exp
            if (_stringValue.Contains("WWDASSAD"))
            {
                game.link.exp += 100;
                _stringValue = "";
                cheatActive = true;
            }

            //WWWDDSSAAA for getting ice sword
            if (_stringValue.Contains("WWWDDSSAAA"))
            {
                game.link.buffList["IceSword"]++;
                _stringValue = "";
                cheatActive = true;
            }

            //prevent too big of a string
            if (_stringValue.Length > 100)
            { _stringValue = _stringValue[85..]; }

            if (cheatActive)
            {
                AudioPlayer.getHeart.Play();
            }

        }

    }
}
