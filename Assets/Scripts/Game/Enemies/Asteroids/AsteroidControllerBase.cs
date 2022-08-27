using Data.Game;
using Game.Player;
using Infrastructure.Services;
using UnityEngine;

namespace Game.Enemies.Asteroids
{
    [RequireComponent(typeof(AsteroidMovement))]
    [RequireComponent(typeof(CollisionHandler))]
    public class AsteroidControllerBase : MonoBehaviour, IDestroyable
    {
        protected ServicesHub hub;
        protected RewardService rewardService;
        protected GameData.Enemies.Asteroids asteroidsSettings;


        protected void Awake()
        {
            hub = ServicesHub.Container;
            
            rewardService = hub.Resolve<RewardService>();
            asteroidsSettings = hub.Resolve<ResourcesService>().GameData.EnemiesSettings.AsteroidsSettings;
        }

        public virtual void Destroy() { }
    }
}