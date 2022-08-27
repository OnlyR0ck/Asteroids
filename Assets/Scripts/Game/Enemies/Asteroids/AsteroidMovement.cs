using Infrastructure.Services;
using UnityEngine;

namespace Game.Enemies
{
    public class AsteroidMovement : MonoBehaviour
    {
        private float currentSpeed;

        private void Awake()
        {
            Vector2 currentSpeedRange = ServicesHub.Container.Resolve<ResourcesService>().GameData.EnemiesSettings
                .AsteroidsSettings.SpeedRange;

            SetSpeed(currentSpeedRange);
        }

        
        public void SetSpeedMultiplier(float speedMultiplier) => currentSpeed *= speedMultiplier;

        
        private void Update() => 
            transform.Translate(transform.forward * (currentSpeed * Time.deltaTime));

        
        private void SetSpeed(Vector2 currentSpeedRange) =>
            currentSpeed = UnityEngine.Random.Range(currentSpeedRange.x, currentSpeedRange.y);
    }
}