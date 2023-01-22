using System;
using UnityEngine;

namespace Game.Player
{
    public class CollisionHandler : MonoBehaviour
    {
        public event Action OnEnter;
        private event Action OnExit;

        public void OnTriggerEnter2D(Collider2D collider) => 
            OnEnter?.Invoke();

        public void OnTriggerExit(Collider collider) => OnExit?.Invoke();
    }
}