using UnityEngine;

namespace Infrastructure.Services
{
    public static class LayerMaskHandler
    {
        public static int Player => LayerMask.NameToLayer("Player");
        
        
        public static int EnemiesLayer => LayerMask.NameToLayer("Enemies");
        
        public static int EnemiesLayerMask 
            => LayerMask.GetMask("Enemies");
    }
}