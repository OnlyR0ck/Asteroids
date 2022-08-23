using System;
using System.Collections.Generic;

namespace Infrastructure.FSM
{
    public class GameStateMachine
    {
        private Dictionary<Type, IExitableState> states;

        public GameStateMachine()
        {
            states = new Dictionary<Type, IExitableState>()
            {
                
            };
        }
    }

    public interface IState
    {
    }

    public interface IExitableState
    {
        void Exit();
    }
}