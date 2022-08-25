using UnityEngine;

namespace Game.Level
{
    public class LevelController : MonoBehaviour
    {
        [field: SerializeField] public Transform PlayerRoot { get; }
        [field: SerializeField] public Transform EnemiesRoot { get; }
    }
}