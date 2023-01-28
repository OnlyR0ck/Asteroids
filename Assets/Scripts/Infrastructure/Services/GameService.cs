using System;
using Game.Level;
using Zenject;

namespace Infrastructure.Services
{
    public class GameService : IService, IGameService
    {
        private readonly IGameObjectsService gameObjectsService;
        private readonly IEnemiesService enemiesService;
        private readonly IPlayerService playerService;

        private LevelController level;
        private readonly IRewardService rewardService;

        public event Action OnPlayerLose;
        
        [Inject]
        public GameService(IGameObjectsService gameObjectsService, IEnemiesService enemiesService, IPlayerService playerService, IRewardService rewardService)
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

        public void StopGame()
        {
            playerService.Stop();
            enemiesService.StopSpawnEntities();
            rewardService.SaveScore();
            
            UnsubscribeFromEvents();
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

        private void PlayerService_OnPlayerKilled() => OnPlayerLose?.Invoke();
    }
}