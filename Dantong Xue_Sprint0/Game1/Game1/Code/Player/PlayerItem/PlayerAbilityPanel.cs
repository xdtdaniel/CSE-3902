using Game1.Code.Player.Interface;
using Game1.Code.Player.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Code.Player.PlayerCharacter;

namespace Game1.Code.Player.PlayerItem
{
    public class PlayerAbilityPanel
    {
        private Link link;
        private ItemPool itemPool;
        private List<IPlayerAbility> abilityList = new List<IPlayerAbility>();

        private int BladeBarrageCoolDown = 10;
        private int timeSinceBladeBarrage = 1800;
        public PlayerAbilityPanel(Link link, ItemPool itemPool)
        {
            this.link = link;
            this.itemPool = itemPool;
        }
        public void UseBladeBarrage()
        {
            if (timeSinceBladeBarrage >= BladeBarrageCoolDown)
            {
                abilityList.Add(new BladeBarrage(link, itemPool));
                timeSinceBladeBarrage = 0;
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
    }
}
