using Data.Game;
using Game.Player;
using Infrastructure.Services;
using UnityEngine;

namespace Game.Enemies
{
    
    [RequireComponent(typeof(UfoMovementController))]
    [RequireComponent(typeof(UfoWeaponController))]
    [RequireComponent(typeof(UfoWeaponController))]
    public class UfoController : MonoBehaviour, IDestroyable
    {
        private GameData.Enemies.UFOs ufoSettings;
        private RewardService rewardService;

        private void Awake()
        {
            ServicesHub hub = ServicesHub.Container;
            ufoSettings = hub.Resolve<ResourcesService>().GameData.EnemiesSettings.UfoSettings;
            
            UfoMovementController ufoMovementController = GetComponent<UfoMovementController>();
            UfoWeaponController ufoWeaponController = GetComponent<UfoWeaponController>();
            CollisionHandler collisionHandler = GetComponent<CollisionHandler>();
        }
        

        public void Destroy()
        {
            rewardService.AddScore(ufoSettings.PointsForDestroy);
            gameObject.SetActive(false);
        }
    }
}