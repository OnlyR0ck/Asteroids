using System;
using UnityEngine;

namespace Infrastructure.Services
{
    public class ProgressService : IService
    {
        public void Init()
        {
            
        }

        public PlayerData PlayerData { get; private set; }
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


    public class GameService : IService
    {
        public event Action OnPlayerLose;

        public void Init()
        {
        
        }

        public void StopGame()
        {
        
        }
    }
}