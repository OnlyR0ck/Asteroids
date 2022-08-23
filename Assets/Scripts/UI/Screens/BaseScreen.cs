using Infrastructure.FSM;
using Infrastructure.Services;
using UnityEngine;

namespace UI.Screens
{
    public class BaseScreen : MonoBehaviour
    {
        protected ServicesHub ServicesHub;
        protected GameStateMachine GameStateMachine;

        public virtual void Init(ServicesHub servicesHub, GameStateMachine gameStateMachine)
        {
            this.ServicesHub = servicesHub;
            this.GameStateMachine = gameStateMachine;
        }

        public void Close() => Destroy(gameObject);
    }
}