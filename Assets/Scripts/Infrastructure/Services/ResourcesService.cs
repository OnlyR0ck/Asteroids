using Data.Game;
using Data.UI;
using Unity.VisualScripting;
using UnityEngine;

public interface IResourcesService
{
    GameData GameData { get; }
    ScreensData Ui { get; set; }
}

namespace Infrastructure.Services
{
    public class ResourcesService : IResourcesService, IInitializable
    {
        private const string GameDataPath = "Data/Game/Data_MainGame";
        
        private GameData gameData;

        public ScreensData Ui { get; set; }
        public GameData GameData => gameData;

        public void Initialize() => gameData = Resources.Load<GameData>(GameDataPath);
    }
}