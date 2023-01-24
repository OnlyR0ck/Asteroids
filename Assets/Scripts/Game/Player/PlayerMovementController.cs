using System;
using System.Collections;
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

        private Coroutine moveCoroutine;
        
        private bool isMoving;
        private float moveCancelledTime;
        private float moveStartTime;

        #endregion


    
        #region Unity lifecycle

        private void OnDisable()
        {
            inputService.OnMoveActionPerformed -= InputService_MoveActionPerformed;
            inputService.OnMoveActionCanceled -= InputService_OnMoveActionCancelled;
            inputService.OnRotateActionPerformed -= InputService_RotateActionPerformed;
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
            
            SubscribeToEvents();
        }

        #endregion


        #region Private Methods

        private void ProcessRotation()
        {
            if (currentRotationType != RotationType.None)
            {
                float rotationSpeed = currentRotationType == RotationType.Clockwise
                    ? playerSettings.RotationSpeed : -playerSettings.RotationSpeed;
                
                transform.Rotate(-Vector3.back, rotationSpeed * Time.deltaTime);
            }
        }


        private void ProcessMovement()
        {
            if (!isMoving && currentSpeed > 0)
            {
                currentSpeed -= playerSettings.Acceleration * (Time.deltaTime * (Time.time - moveCancelledTime));
            }
            
            transform.Translate(transform.up * (currentSpeed * Time.deltaTime));
        }

        private void SubscribeToEvents()
        {
            inputService.OnMoveActionPerformed += InputService_MoveActionPerformed;
            inputService.OnMoveActionCanceled += InputService_OnMoveActionCancelled;
            inputService.OnRotateActionPerformed += InputService_RotateActionPerformed;
            inputService.OnRotateActionCancelled += InputService_RotateActionCancelled;
        }

        #endregion


        #region Event Handlers

        private void InputService_RotateActionPerformed(float rotationAxis)
        {
            if (Math.Sign(rotationAxis) > 0)
            {
                currentRotationType = RotationType.Clockwise;
            }
            else if (Math.Sign(rotationAxis) < 0)
            {
                currentRotationType = RotationType.CounterClockwise;
            }
            
            
            Debug.Log($"Rotation Axis: {rotationAxis}");
        }


        private void InputService_RotateActionCancelled()
        {
            currentRotationType = RotationType.None;
        }


        private void InputService_MoveActionPerformed(float moveStartTime)
        {
            isMoving = true;
            this.moveStartTime = moveStartTime;
            
            moveCoroutine = StartCoroutine(Coroutine_MoveCoroutine());
        }

        private void InputService_OnMoveActionCancelled(float time)
        {
            isMoving = false;
            moveCancelledTime = time;
            moveStartTime = 0;
            
            StopCoroutine(moveCoroutine);
        }

        #endregion

        IEnumerator Coroutine_MoveCoroutine()
        {
            while (isMoving)
            {
                float holdDuration = Time.time - moveStartTime;
                currentSpeed = holdDuration * playerSettings.Acceleration;
                currentSpeed = Mathf.Clamp(Math.Abs(currentSpeed), 0, playerSettings.MaxSpeed);
                yield return null;
            }
        }
    }
}