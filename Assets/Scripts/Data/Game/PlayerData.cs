using UnityEngine;

namespace Infrastructure.Services
{
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