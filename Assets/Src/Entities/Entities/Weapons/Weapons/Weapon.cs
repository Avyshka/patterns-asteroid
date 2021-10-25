using System;
using Asteroids.Entities.Entities.Weapons.Interfaces;
using UnityEngine;

namespace Asteroids.Entities.Entities.Weapons.Weapons
{
    public class Weapon : IWeapon
    {
        public event Action<Transform> Shoot;

        public void Fire(Transform transform)
        {
            Shoot?.Invoke(transform);
        }
    }
}