using Data.Game;
using Data.UI;
using UnityEngine;

namespace Infrastructure.Services
{
    public class ResourcesService : IService
    {
        private const string GameDataPath = "Data/Game/Data_MainGame";
        
        private GameData gameData;

        public ScreensData Ui { get; set; }
        public GameData GameData => gameData ??= Resources.Load<GameData>(GameDataPath);

        public void Init()
        {
            
        }
    }
}