using UnityEngine;

namespace Infrastructure.Services
{
    public class ProgressService : IService
    {
        private PlayerData playerData;


        public ProgressService()
        {
            playerData = new PlayerData();
        }
        
        
        public void Init()
        {
            
        }

        public PlayerData PlayerData => playerData;
    }

    public class PlayerData
    {
        private const string HighScoreKey = "PlayerHighScore";

        public int HighScore
        {
            get => PlayerPrefs.GetInt(HighScoreKey, 0);
            set
            {
                if (value > 0)
                {
                    PlayerPrefs.SetInt(HighScoreKey, value);
                }
            }
        }
    }
}