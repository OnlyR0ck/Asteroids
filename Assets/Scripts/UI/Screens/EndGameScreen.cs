using Infrastructure.FSM.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class EndGameScreen : BaseScreen
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        

        private void OnEnable()
        {
            restartButton.onClick.AddListener(RestartButton_OnClick);
            menuButton.onClick.AddListener(MenuButton_OnClick);
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