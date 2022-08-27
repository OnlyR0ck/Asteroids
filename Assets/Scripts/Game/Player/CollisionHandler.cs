using System;
using UnityEngine;
using Action = Unity.Plastic.Antlr3.Runtime.Misc.Action;

namespace Game.Player
{
    public class CollisionHandler : MonoBehaviour
    {
        public event Action OnEnter;
        private event Action OnExit;

        public void OnTriggerEnter2D(Collider2D collider) => 
            OnEnter?.Invoke();

        public void OnTriggerExit(Collider collider)
        {
            OnExit?.Invoke();
        }
    }
}