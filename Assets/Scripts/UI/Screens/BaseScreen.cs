using UnityEngine;

namespace UI.Screens
{
    public class BaseScreen : MonoBehaviour
    {
        public virtual void Init()
        {
            
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}