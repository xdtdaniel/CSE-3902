using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    interface IPlayerController
    {
        void Update();

        int Direction();

        bool IsMoving();
        bool PressedAttackN();
        bool PressedAttackZ();
        bool IsDamaged();
        int PickUp();
    }
}
