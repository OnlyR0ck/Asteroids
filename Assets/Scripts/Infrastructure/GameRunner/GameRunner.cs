using Infrastructure.FSM;
using Infrastructure.FSM.States;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.GameRunner
{
    public class GameRunner : MonoBehaviour, ICoroutineRunner
    {
        private ServicesHub servicesHub;
        private GameStateMachine gameStateMachine;
    
        private void Awake()
        {
            servicesHub = new ServicesHub();
            gameStateMachine = new GameStateMachine(servicesHub);
            
            servicesHub.Init(gameStateMachine, this);
            gameStateMachine.EnterState<BootState>();
        }
    }
}