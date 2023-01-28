using System;

namespace Infrastructure.Services
{
    public interface IGameService
    {
        event Action OnPlayerLose;
        void Init();
        void PrepareForGame();
        void StartGame();
        void StopGame();
    }
}