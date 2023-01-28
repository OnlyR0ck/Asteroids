using Infrastructure.FSM;
using Infrastructure.Services;
using UnityEngine;

namespace UI.Screens
{
    public class BaseScreen : MonoBehaviour
    {
        protected GameStateMachine GameStateMachine;

        public virtual void Init(GameStateMachine gameStateMachine) =>
            GameStateMachine = gameStateMachine;

        public void Close() => Destroy(gameObject);
    }
}