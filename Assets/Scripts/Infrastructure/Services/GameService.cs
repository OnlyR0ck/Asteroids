using System;
using Game.Level;

namespace Infrastructure.Services
{
    public class GameService : IService
    {
        private readonly GameObjectsService gameObjectsService;
        private readonly EnemiesService enemiesService;
        private readonly PlayerService playerService;

        private LevelController level;
        private readonly RewardService rewardService;

        public event Action OnPlayerLose;

        public GameService(GameObjectsService gameObjectsService, EnemiesService enemiesService, PlayerService playerService, RewardService rewardService)
        {
            this.gameObjectsService = gameObjectsService;
            this.enemiesService = enemiesService;
            this.playerService = playerService;
            this.rewardService = rewardService;
        }


        
        public void Init() { }

        
        
        public void PrepareForGame()
        {
            level = gameObjectsService.CreateLevel().GetComponent<LevelController>();
            rewardService.ResetCurrentScore();
        }

        public void StartGame()
        {
            playerService.OnPlayerKilled += PlayerService_OnPlayerKilled;

            SpawnGameEntities();
            SubscribeToEvents();
        }

        private void SpawnGameEntities()
        {
            playerService.SpawnPlayer(level);
            enemiesService.StartSpawnEnemies(level);
        }

        private void SubscribeToEvents() => 
            playerService.OnPlayerKilled += PlayerService_OnPlayerKilled;

        private void UnsubscribeFromEvents() => 
            playerService.OnPlayerKilled -= PlayerService_OnPlayerKilled;

        public void StopGame()
        {
            playerService.Stop();
            enemiesService.StopSpawnEntities();
            rewardService.SaveScore();
            
            UnsubscribeFromEvents();
        }

        private void PlayerService_OnPlayerKilled() => OnPlayerLose?.Invoke();
    }


    public enum PooledObjectType
    {
        None            = 0,
        Asteroid        = 1,
        AsteroidPiece   = 2,
        Ufo             = 3,
        Bullet    = 4,
        EnemyBullet     = 5
    }
}