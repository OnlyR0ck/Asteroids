using Infrastructure.Services;

namespace Infrastructure.FSM.States
{
    public class GameplayState : IState
    {
        private readonly GameService gameService;
        private readonly InputService inputService;
        private readonly GameStateMachine gameStateMachine;

        public GameplayState(GameService gameService, GameStateMachine gameStateMachine, InputService inputService)
        {
            this.gameService = gameService;
            this.gameStateMachine = gameStateMachine;
            this.inputService = inputService;
        }
        
        
        public void Enter()
        {
            gameService.OnPlayerLose += GameService_OnPlayerLose;
            inputService.EnablePlayerInput();
        }

        
        public void Exit()
        {
            gameService.OnPlayerLose -= GameService_OnPlayerLose;
            inputService.DisablePlayerInput();
        }

        
        private void GameService_OnPlayerLose()
        {
            gameStateMachine.EnterState<EndGameState>();
            gameService.StopGame();
        }
    }
}