using System;
using System.Collections.Generic;
using Infrastructure.FSM.States;
using Infrastructure.Services;

namespace Infrastructure.FSM
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> states;
        private IExitableState currentState;

        public GameStateMachine(ServicesHub servicesHub)
        {
            states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootState)] = new BootState(gameStateMachine: this),
                
                [typeof(MainMenuState)] = new MainMenuState(
                    servicesHub.Resolve<UIScreenService>(),
                    servicesHub.Resolve<ProgressService>()),
                
                [typeof(StartGameState)] = new StartGameState(
                    servicesHub.Resolve<GameService>(),
                    servicesHub.Resolve<UIScreenService>(),
                    gameStateMachine: this),
                
                [typeof(GameplayState)] = new GameplayState(
                    servicesHub.Resolve<GameService>(),
                    gameStateMachine: this,
                    servicesHub.Resolve<InputService>()),
                
                [typeof(EndGameState)] = new EndGameState(servicesHub)
            };
        }


        public void EnterState<TState>() where TState : class, IState
        {
            IState newState = ChangeState<TState>();
            newState?.Enter();
        }
        
        
        private TState ChangeState<TState>() where TState : class, IState
        {
            currentState?.Exit();

            TState newState = GetState<TState>();
            currentState = newState;

            return newState;
        }

        
        private TState GetState<TState>() where TState : class, IState => 
            states[typeof(TState)] as TState;
    }
}