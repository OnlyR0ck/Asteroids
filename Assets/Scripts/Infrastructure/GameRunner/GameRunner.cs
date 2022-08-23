using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.GameRunner
{
    public class GameRunner : MonoBehaviour
    {
        private ServicesHub servicesHub;
    
        private void Awake()
        {
            servicesHub = new ServicesHub();
            servicesHub.Init();
        }
    }
}