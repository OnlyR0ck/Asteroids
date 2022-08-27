using System;
using Data.Game;
using Infrastructure.Services;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Nested Types

        private enum RotationType
        {
            None               = 0,
            Clockwise          = 1,
            CounterClockwise   = 2
        }

        #endregion



        #region Fields

        private ResourcesService resourcesService;
        private GameData.Player playerSettings;
        private InputService inputService;

        private RotationType currentRotationType;
    
        private float currentSpeed;
    
        private bool isMoving;
        private float moveCancelledTime;

        #endregion


    
        #region Unity lifecycle

        private void OnEnable()
        {
            inputService.OnMoveActionPerformed += InputService_MoveActionPerformed;
            inputService.OnMoveActionCanceled += InputService_OnMoveActionCancelled;
            inputService.OnRotateAction += InputService_OnRotateAction;
        }


        private void OnDisable()
        {
            inputService.OnMoveActionPerformed -= InputService_MoveActionPerformed;
            inputService.OnMoveActionCanceled -= InputService_OnMoveActionCancelled;
            inputService.OnRotateAction -= InputService_OnRotateAction;
        }

    
        private void Update()
        {
            ProcessMovement();
            ProcessRotation();
        }

        #endregion


        #region Public Methods

        public void Init(ResourcesService resourcesService, InputService inputService)
        {
            this.inputService = inputService;
            this.resourcesService = resourcesService;
        
            playerSettings = resourcesService.GameData.PlayerSettings;
        }

        #endregion


        private void InputService_OnRotateAction(float rotationAxis)
        {
            if (Math.Sign(rotationAxis) > 0)
            {
                currentRotationType = RotationType.Clockwise;
            }
            else if(Math.Sign(rotationAxis) <= 0)
            {
                currentRotationType = RotationType.CounterClockwise;
            }
            else
            {
                currentRotationType = RotationType.None;
            }
        }


        private void ProcessRotation()
        {
            if (currentRotationType != RotationType.None)
            {
                transform.Rotate(-Vector3.back, playerSettings.RotationSpeed);
            }
        }

        private void ProcessMovement()
        {
            if (!isMoving && currentSpeed > 0)
            {
                currentSpeed -= playerSettings.Acceleration * (Time.deltaTime * (Time.time - moveCancelledTime));
            }
        
            transform.Translate(transform.forward * (currentSpeed * Time.deltaTime));
        }

    
        private void InputService_OnMoveActionCancelled(float time)
        {
            isMoving = false;
            moveCancelledTime = time;
        }


        private void InputService_MoveActionPerformed(float holdDuration)
        {
            currentSpeed = holdDuration * playerSettings.Acceleration;
            isMoving = true;
        }
    }
}