namespace Zenject
{
    public abstract class InstallerBase : IInstaller
    {
        [Inject]
        DiContainer _container = null;

        protected DiContainer Container => _container;

        public virtual bool IsEnabled => true;

        public abstract void InstallBindings();
    }
}
