using System;
using Data.Game;

namespace Infrastructure.Services
{
    public class GameService : IService
    {
        private ResourcesService resourcesService;
        private GameData gameData;
        public event Action OnPlayerLose;

        public GameService(ResourcesService resourcesService)
        {
            this.resourcesService = resourcesService;
        }
        
        
        public void Init()
        {
            gameData = resourcesService.GameData;
        }

        public void StartGame()
        {
            
        }

        public void StopGame()
        {
            
        }
    }
}