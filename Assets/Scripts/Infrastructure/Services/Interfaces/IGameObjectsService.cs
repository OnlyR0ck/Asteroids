using Types.Pool;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IGameObjectsService
    {
        GameObject GetPooledObject(PooledObjectType key);
        GameObject CreatePlayer();
        GameObject CreateLevel();
        GameObject GetObjectByType(PooledObjectType type);
    }
}