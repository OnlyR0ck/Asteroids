using UI.Screens;

namespace Infrastructure.Services
{
    public interface IUIScreenService
    {
        void Initialize();
        void ShowScreen<TScreenType>() where TScreenType : BaseScreen;
    }
}