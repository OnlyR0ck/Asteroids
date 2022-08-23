using Infrastructure.Services;
using UI.Screens;

namespace Infrastructure.FSM.States
{
    public class EndGameState : IState
    {
        private readonly ServicesHub servicesHub;
        private readonly UIScreenService uiScreenService;

        public EndGameState(ServicesHub servicesHub)
        {
            this.servicesHub = servicesHub;

            this.uiScreenService = servicesHub.Resolve<UIScreenService>();
        }

        public void Enter()
        {
            uiScreenService.ShowScreen<EndGameScreen>();
            
        }

        public void Exit()
        {
            
        }
    }
}