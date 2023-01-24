using Data.Game;
using Data.UI;
using UnityEngine;

namespace Infrastructure.Services
{
    public class ResourcesService : IService
    {
        private const string GameDataPath = "Data/Game/Data_MainGame";
        private const string ScreensDataPath = "Data/UI/Data_Screens";

        private GameData gameData;
        private ScreensData uiData;
        
        
        
        public ScreensData Ui => uiData ??= Resources.Load<ScreensData>(ScreensDataPath);

        public GameData GameData => gameData ??= Resources.Load<GameData>(GameDataPath);

        public void Init()
        {
            
        }
    }
}