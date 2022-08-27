using System;
using System.Net;
using Infrastructure.Services;
using UnityEditor;
using UnityEngine;
using Action = Unity.Plastic.Antlr3.Runtime.Misc.Action;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(CollisionHandler))]

    public class PlayerController : MonoBehaviour
    {
        private PlayerMovementController movementController;
        private CollisionHandler collisionHandler;
        private ServicesHub hub;

        public event Action OnDamaged;

        private void Awake()
        {
            hub = ServicesHub.Container;
            
            movementController = GetComponent<PlayerMovementController>();
            collisionHandler = GetComponent<CollisionHandler>();


            movementController.Init(
                hub.Resolve<ResourcesService>(), 
                hub.Resolve<InputService>());
        }

        private void OnEnable() => collisionHandler.OnEnter += CollisionHandler_OnEnter;

        private void OnDisable() => collisionHandler.OnEnter -= CollisionHandler_OnEnter;

        private void CollisionHandler_OnEnter() => OnDamaged?.Invoke();
    }
    
}