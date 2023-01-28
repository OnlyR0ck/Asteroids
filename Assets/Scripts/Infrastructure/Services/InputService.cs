using System;
using UnityEngine.InputSystem;
using Zenject;


namespace Infrastructure.Services
{
    public class InputService : IInputService, IInitializable
    {
        private PlayerInputAsset playerInput;
        private InputAction moveAction;
        private InputAction rotateAction;
        private InputAction firstFireAction;
        private InputAction secondFireAction;
        public event Action OnFirstFireAction;
        public event Action OnSecondFireAction;
        public event Action<float> OnMoveActionPerformed;
        public event Action<float> OnMoveActionCanceled;
        
        public event Action<float> OnRotateAction;

        public void Initialize()
        {
            playerInput = new PlayerInputAsset();
            
            moveAction = playerInput.Player.Move;
            rotateAction = playerInput.Player.Look;
            firstFireAction = playerInput.Player.Fire1;
            secondFireAction = playerInput.Player.Fire2;
        }

        public void EnablePlayerInput()
        {
            moveAction.Enable();
            rotateAction.Enable();
            firstFireAction.Enable();
            secondFireAction.Enable();
            
            moveAction.performed += MoveAction_Performed;
            moveAction.canceled += MoveAction_Canceled;
            rotateAction.performed += RotateAction_Performed;
            firstFireAction.performed += FirstFireAction_Performed;
            secondFireAction.performed += SecondFireAction_Performed;
        }

        public void DisablePlayerInput()
        {
            moveAction.Disable();
            rotateAction.Disable();
            firstFireAction.Disable();
            secondFireAction.Disable();
            
            moveAction.performed -= MoveAction_Performed;
            moveAction.canceled -= MoveAction_Canceled;
            rotateAction.performed -= RotateAction_Performed;
            firstFireAction.performed -= FirstFireAction_Performed;
            secondFireAction.performed -= SecondFireAction_Performed;
        }

        private void MoveAction_Performed(InputAction.CallbackContext ctx) =>
            OnMoveActionPerformed?.Invoke((float) ctx.duration);

        private void MoveAction_Canceled(InputAction.CallbackContext ctx) =>
            OnMoveActionCanceled?.Invoke((float) ctx.time);

        private void RotateAction_Performed(InputAction.CallbackContext ctx) => 
            OnRotateAction?.Invoke(rotateAction.ReadValue<float>());

        private void FirstFireAction_Performed(InputAction.CallbackContext ctx) => 
            OnFirstFireAction?.Invoke();

        private void SecondFireAction_Performed(InputAction.CallbackContext ctx) =>
            OnSecondFireAction?.Invoke();
    }
}