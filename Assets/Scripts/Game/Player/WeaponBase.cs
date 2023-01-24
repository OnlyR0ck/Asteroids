using System;
using Infrastructure.Services;
using UnityEngine;

namespace Game.Player
{
    public class WeaponBase : MonoBehaviour
    {
        protected ResourcesService resourcesService;
        protected ServicesHub hub;

        protected void Awake()
        {
            hub = ServicesHub.Container;

            resourcesService = hub.Resolve<ResourcesService>();
        }
    }
}