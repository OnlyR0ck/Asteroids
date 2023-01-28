using System;
using Game.Level;
using Game.Player;

namespace Infrastructure.Services
{
    public interface IPlayerService
    {
        event Action OnPlayerKilled;
        IPlayer Player { get; }
        void Init();
        void SpawnPlayer(LevelController level);
        void Stop();
    }
}