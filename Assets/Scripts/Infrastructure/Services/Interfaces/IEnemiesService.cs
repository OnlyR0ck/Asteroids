using Game.Level;

namespace Infrastructure.Services
{
    public interface IEnemiesService
    {
        void StartSpawnEnemies(LevelController level);
        void StopSpawnEntities();
    }
}