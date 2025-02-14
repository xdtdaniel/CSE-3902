﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Code.Player.Interface
{
    public interface IPlayerAbility
    {
        void Update();
        void Use();
        string GetAbilityName();
        bool IsLearned();
        void Learn();
        float GetCooldownPercentage();
        float GetRemainingCooldown();
        void Draw(SpriteBatch sb);
        void Updatelocation(float newStartX, float newStartY);
    }
}
