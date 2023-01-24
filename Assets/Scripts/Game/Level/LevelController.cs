using UnityEngine;

namespace Game.Level
{
    public class LevelController : MonoBehaviour
    { 
        [field: SerializeField] public Transform PlayerRoot { get; set; } 
        [field: SerializeField] public Transform EnemiesRoot { get; set; }
    }
}