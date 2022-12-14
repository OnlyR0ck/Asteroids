using Infrastructure.Services;
using UI.Screens;

namespace Infrastructure.FSM.States
{
    public class MainMenuState : IState
    {
        private readonly UIScreenService uiScreenService;
        private readonly ProgressService progressService;

        public MainMenuState(UIScreenService uiScreenService, ProgressService progressService)
        {
            this.uiScreenService = uiScreenService;
            this.progressService = progressService;
        }
        public void Enter() => uiScreenService.ShowScreen<MenuScreen>();

        public void Exit()
        {
            
        }
    }
}