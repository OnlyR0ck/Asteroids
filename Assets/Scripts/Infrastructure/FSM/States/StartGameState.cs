using Infrastructure.Services;
using UI.Screens;

namespace Infrastructure.FSM.States
{
    public class StartGameState : IState
    {
        private readonly GameService gameService;
        private readonly UIScreenService uiScreenService;
        private readonly GameStateMachine gameStateMachine;

        public StartGameState(GameService gameService, UIScreenService uiScreenService, 
            GameStateMachine gameStateMachine)
        {
            this.gameService = gameService;
            this.uiScreenService = uiScreenService;
            this.gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
            uiScreenService.ShowScreen<GameScreen>();
            gameService.StartGame();
            gameStateMachine?.EnterState<GameplayState>();
        }

        public void Exit()
        {
        }
    }
}