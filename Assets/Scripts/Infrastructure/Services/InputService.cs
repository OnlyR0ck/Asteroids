using Unity.Plastic.Antlr3.Runtime.Misc;

namespace Infrastructure.Services
{
    public class InputService : IService
    {
        public event Action OnMoveAction;

        public event Action OnAttackAction;
        

        public void Init()
        {
            
        }
    }
}