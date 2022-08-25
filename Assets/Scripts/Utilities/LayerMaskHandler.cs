using UnityEngine;

namespace Infrastructure.Services
{
    public static class LayerMaskHandler
    {
        public static int Player => LayerMask.NameToLayer("Player");
        
        
        public static int Enemies => LayerMask.NameToLayer("Enemies");
    }
}