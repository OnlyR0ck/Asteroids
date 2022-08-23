namespace Infrastructure.FSM.State
{
    public class BootState : IState
    {
        private readonly GameStateMachine gameStateMachine;

        public BootState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }
        
        
        public void Enter() => gameStateMachine.EnterState<MainMenuState>();

        public void Exit() { }
    }
}