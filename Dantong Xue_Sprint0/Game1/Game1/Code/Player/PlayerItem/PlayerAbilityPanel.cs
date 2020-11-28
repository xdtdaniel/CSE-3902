using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Zelda.Code.Player.PlayerCharacter;

namespace Game1.Code.Player.PlayerItem
{
    public class PlayerAbilityPanel
    {
        private Link link;
        private ItemPool itemPool;
        private List<IPlayerAbility> abilityList = new List<IPlayerAbility>();

        public List<bool> swordAbilityTree = new List<bool>();
        private int swordAbilityTreeLength = 4;
        public List<bool> bowAbilityTree = new List<bool>();
        private int bowAbilityTreeLength = 4;
        public List<List<bool>> treeList = new List<List<bool>>();

        private int BladeBarrageCoolDown = 10;
        private int timeSinceBladeBarrage = 1800;
        public PlayerAbilityPanel(Link link, ItemPool itemPool)
        {
            this.link = link;
            this.itemPool = itemPool;

            for (int i = 0; i < swordAbilityTreeLength; i++)
            {
                swordAbilityTree.Add(false);
            }
            for (int i = 0; i < bowAbilityTreeLength; i++)
            {
                bowAbilityTree.Add(false);
            }
            treeList.Add(swordAbilityTree);
            treeList.Add(bowAbilityTree);
        }
        public void UseBladeBarrage()
        {
            if (timeSinceBladeBarrage >= BladeBarrageCoolDown)
            {
                abilityList.Add(new BladeBarrage(link, itemPool));
                timeSinceBladeBarrage = 0;
            }
        }
        public void Learn(int type, int index)
        {
            if (link.abilityPoint > 0 && index > 0 && treeList[type][index - 1])
            {
                treeList[type][index] = true;
                link.abilityPoint--;
            }
        }
        public void Update()
        {

            for (int i = 0; i < abilityList.Count; i++)
            {
                abilityList[i].Update();
                if (abilityList[i].IsDone())
                {
                    abilityList.RemoveAt(i);
                    i--;
                }
            }
            
            if (timeSinceBladeBarrage < BladeBarrageCoolDown)
            {
                timeSinceBladeBarrage++;
            }
        }
        public int GetNumOfAbilities()
        {
            return swordAbilityTreeLength + bowAbilityTreeLength;
        }
        public int GetGlobalIndex(int type, int index)
        {
            int globalIndex = 0;
            for (int i = 0; i < type; i++)
            {
                globalIndex += treeList[i].Count;
            }
            globalIndex += index;
            return globalIndex;
        }
    }
}
