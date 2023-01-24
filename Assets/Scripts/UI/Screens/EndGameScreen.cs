using System;
using Infrastructure.FSM.States;
using Infrastructure.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class EndGameScreen : BaseScreen
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;

        [SerializeField] private TextMeshProUGUI highScoreTMP;
        [SerializeField] private TextMeshProUGUI currentScoreTMP;
        private RewardService rewardService;
        private ProgressService progressService;


        private void Awake()
        {
            progressService = ServicesHub.Container.Resolve<ProgressService>();
            rewardService = ServicesHub.Container.Resolve<RewardService>();
        }

        
        private void OnEnable()
        {
            restartButton.onClick.AddListener(RestartButton_OnClick);
            menuButton.onClick.AddListener(MenuButton_OnClick);
            
            InitScreen();
        }
        

        private void InitScreen()
        {
            if (rewardService.CurrentScore > progressService.PlayerData.HighScore)
            {
                currentScoreTMP.text = $"NEW HIGHSCORE: {rewardService.CurrentScore.ToString()}";
                highScoreTMP.text = "";
            }
            else
            {
                highScoreTMP.text = $"HIGHSCORE: {progressService.PlayerData.HighScore.ToString()}";
                currentScoreTMP.text = $"YOUR SCORE: {rewardService.CurrentScore.ToString()}";
            }
        }

        
        private void OnDisable()
        {
            restartButton.onClick.RemoveListener(RestartButton_OnClick);
            menuButton.onClick.RemoveListener(MenuButton_OnClick);
        }
    
    
        private void MenuButton_OnClick() => GameStateMachine.EnterState<MainMenuState>();

    
        private void RestartButton_OnClick() => GameStateMachine.EnterState<StartGameState>();
    }
}