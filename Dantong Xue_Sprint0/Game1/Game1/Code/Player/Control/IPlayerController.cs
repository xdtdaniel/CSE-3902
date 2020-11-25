
namespace Game1.Code.Player.Control
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
