using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.Code.Achievement.Tracker
{
    public interface ITracker
    {
        bool Update(bool startDrawing);
        void Draw();
        bool AchievementCompleted();
    }
}
