using System;

namespace Infrastructure.Services
{
    public interface IInputService
    {
        event Action OnFirstFireAction;
        event Action OnSecondFireAction;
        event Action<float> OnMoveActionPerformed;
        event Action<float> OnMoveActionCanceled;
        event Action<float> OnRotateAction;
        void EnablePlayerInput();
        void DisablePlayerInput();
    }
}