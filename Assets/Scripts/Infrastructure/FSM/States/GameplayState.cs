using Infrastructure.Services;

namespace Infrastructure.FSM.States
{
    public class GameplayState : IState
    {
        private readonly GameService gameService;
        private GameStateMachine gameStateMachine;

        public GameplayState(GameService gameService, GameStateMachine gameStateMachine)
        {
            this.gameService = gameService;
            this.gameStateMachine = gameStateMachine;
        }
        
        
        public void Enter()
        {
            gameService.OnPlayerLose += GameService_OnPlayerLose;
        }

        
        public void Exit()
        {
            gameService.OnPlayerLose -= GameService_OnPlayerLose;
        }

        
        private void GameService_OnPlayerLose()
        {
            gameStateMachine.EnterState<EndGameState>();
            gameService.StopGame();
        }
    }
}