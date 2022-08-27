using Game.Enemies.Asteroids;

namespace Game.Enemies
{
    public class AsteroidPieceController : AsteroidControllerBase
    {
        public override void Destroy()
        {
            rewardService.AddScore(asteroidsSettings.PointsForDestroy);
            gameObject.SetActive(false);
        }
    }
}