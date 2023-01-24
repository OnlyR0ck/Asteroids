using Infrastructure.FSM;
using Infrastructure.FSM.States;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.GameRunner
{
    public class GameRunner : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private GameSceneReferencesService gameSceneReferencesService;
        
        private ServicesHub servicesHub;
        private GameStateMachine gameStateMachine;
    
        private void Awake()
        {
            servicesHub = new ServicesHub(this);

            gameSceneReferencesService.Init();

            gameStateMachine = new GameStateMachine(servicesHub);
            gameStateMachine.EnterState<BootState>();
        }
    }
}