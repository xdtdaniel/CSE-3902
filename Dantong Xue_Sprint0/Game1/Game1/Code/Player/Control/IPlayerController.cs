
namespace Game1
{
    interface IPlayerController
    {
        void Update();

        string Direction();

        bool IsMoving();
        bool PressedAttackN();
        bool PressedAttackZ();
        bool IsDamaged();
        int PickUp();
    }
}
