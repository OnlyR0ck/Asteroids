using Unity.Plastic.Antlr3.Runtime.Misc;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action OnEnter;

    public void OnTriggerEnter2D(Collider2D collider) => 
        OnEnter?.Invoke();
}