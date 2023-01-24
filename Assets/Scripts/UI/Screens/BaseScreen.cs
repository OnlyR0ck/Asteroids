using Infrastructure.FSM;
using Infrastructure.Services;
using UnityEngine;

namespace UI.Screens
{
    public class BaseScreen : MonoBehaviour
    {
        protected ServicesHub ServicesHub;
        protected GameStateMachine GameStateMachine;

        public virtual void Init(ServicesHub servicesHub)
        {
            this.ServicesHub = servicesHub;
            this.GameStateMachine = GameStateMachine.Instance;
        }

        public void Close() => Destroy(gameObject);
    }
}