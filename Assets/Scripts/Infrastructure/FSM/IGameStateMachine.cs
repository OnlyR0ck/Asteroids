namespace Infrastructure.FSM
{
    public interface IGameStateMachine
    {
        void EnterState<TState>() where TState : class, IState;
    }
}