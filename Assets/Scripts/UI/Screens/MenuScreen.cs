using Infrastructure.FSM;
using Infrastructure.FSM.States;
using Infrastructure.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class MenuScreen : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI highScoreTMP;
        [SerializeField] private Button pressToPlayButton;
        
        private ProgressService progressService;

        
        
        private void OnEnable() => 
            pressToPlayButton.onClick.AddListener(PressToPlayButton_OnClick);

        
        private void OnDisable() =>
            pressToPlayButton.onClick.AddListener(PressToPlayButton_OnClick);

        
        
        public override void Init(ServicesHub servicesHub)
        {
            base.Init(servicesHub);
            
            progressService = servicesHub.Resolve<ProgressService>();

            highScoreTMP.text = $"{progressService.PlayerData.HighScore.ToString()}";
        }

        
        
        private void PressToPlayButton_OnClick() => 
            GameStateMachine?.EnterState<StartGameState>();
    }
}