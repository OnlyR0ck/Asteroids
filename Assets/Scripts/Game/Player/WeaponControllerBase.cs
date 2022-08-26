using System;
using System.Collections.Generic;
using Infrastructure.Services;
using UnityEngine;

public class WeaponControllerBase : MonoBehaviour
{
    protected WeaponType currentWeapon;

    protected ServicesHub hub;
    protected ResourcesService resourcesService;
    protected GameObjectsService gameObjectsService;

    protected void Awake()
    {
        hub = ServicesHub.Container;

        resourcesService = hub.Resolve<ResourcesService>();
        gameObjectsService = hub.Resolve<GameObjectsService>();

    }
}