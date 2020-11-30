using Game1.Code.Audio;
using Game1.Code.Player.Control.PlayerControlCommand;
using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter;
using Game1.Code.Player.PlayerCharacter.LinkState;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Zelda.Code.Player.PlayerCharacter;

namespace Game1.Code.Player.PlayerAbility
{
    public class PlayerAbilityPanel
    {
        private Link link;
        private ItemPool itemPool;
        private Game1 game;

        private Dictionary<int, IPlayerAbility> swordAbilityDict = new Dictionary<int, IPlayerAbility>();
        private Dictionary<int, IPlayerAbility> bowAbilityDict = new Dictionary<int, IPlayerAbility>();
        public List<Dictionary<int, IPlayerAbility>> abilityDictList = new List<Dictionary<int, IPlayerAbility>>();

        private List<Keys> availableKeys = new List<Keys>();
        public Dictionary<int, Tuple<int, int>> registeredAbilities = new Dictionary<int, Tuple<int, int>>();
        private int nextRegisterKey = 0;

        public PlayerAbilityPanel(Game1 game)
        {
            this.link = game.link;
            this.itemPool = game.link.itemPool;
            this.game = game;


            swordAbilityDict.Add(0, new BladeBarrage(link, itemPool));
            swordAbilityDict.Add(1, new DeadlySlash(link, itemPool));
            swordAbilityDict.Add(2, new LineImpact(link, itemPool));
            swordAbilityDict.Add(3, new FieldBlast(link, itemPool));
            bowAbilityDict.Add(0, new BladeBarrage(link, itemPool));
            bowAbilityDict.Add(1, new BladeBarrage(link, itemPool));
            bowAbilityDict.Add(2, new BladeBarrage(link, itemPool));
            bowAbilityDict.Add(3, new BladeBarrage(link, itemPool));
            abilityDictList.Add(swordAbilityDict);
            abilityDictList.Add(bowAbilityDict);

            

            availableKeys.Add(Keys.D1);
            availableKeys.Add(Keys.D2);
            availableKeys.Add(Keys.D3);
            availableKeys.Add(Keys.D4);
            availableKeys.Add(Keys.D5);
            availableKeys.Add(Keys.D6);
            availableKeys.Add(Keys.D7);
            availableKeys.Add(Keys.D8);
            availableKeys.Add(Keys.D9);
            availableKeys.Add(Keys.D0);
        }

        // abilities
        public void UseAbility(int type, int index)
        {
            if (abilityDictList[type][index].GetCooldownPercentage() >= 1) // 1 means ability is ready
            {
                link.state = new UseItemLink(link);
                abilityDictList[type][index].Use();
            }
        }


        public void Learn(int type, int index)
        {
            if (!abilityDictList[type][index].IsLearned() && link.abilityPoint > 0 && (index == 0 || abilityDictList[type][index - 1].IsLearned()))
            {
                AudioPlayer.getRupee.Play();
                abilityDictList[type][index].Learn();
                link.abilityPoint--;

                game.playerPanel.linkKeyboardController.RegisterCommand(availableKeys[0], new UseAbility(game, type, index));
                availableKeys.RemoveAt(0);

                registeredAbilities.Add(nextRegisterKey, new Tuple<int, int>(type, index));
                nextRegisterKey++;
            }
        }
        public void Update()
        {

            for (int i = 0; i < abilityDictList.Count; i++)
            {
                for (int j = 0; j < abilityDictList[i].Count; j++)
                {
                    abilityDictList[i][j].Update();
                }
            }

        }
        public int GetNumOfAbilities()
        {
            int num = 0;
            for (int i = 0; i < abilityDictList.Count; i++)
            {
                num += abilityDictList[i].Count;
            }
            return num;
        }
        public int GetGlobalIndex(int type, int index)
        {
            int globalIndex = 0;
            for (int i = 0; i < type; i++)
            {
                globalIndex += abilityDictList[i].Count;
            }
            globalIndex += index;
            return globalIndex;
        }
    }
}
