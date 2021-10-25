using Asteroids.Entities.Enums;
using Asteroids.Entities.Interfaces;
using Asteroids.Interfaces;
using Asteroids.Pools;
using Asteroids.ScriptableObjects;
using Asteroids.Weapons.Controllers;
using Asteroids.Weapons.Models;
using Asteroids.Weapons.Views;
using UnityEngine;

namespace Asteroids.Entities.Entities.Weapons.Factories
{
    public sealed class BulletFactory : IEntityFactory
    {
        public IUpdatable Create(EntityTypes type)
        {
            var data = Resources.Load<BulletData>(EntityData.BulletData.ToString());
            var bullet = ViewServices.Instance.Instantiate(Resources.Load<GameObject>(type.ToString()));
            return new BulletController(
                new BulletModel(data),
                bullet.GetComponent<Bullet>()
            );
        }
    }
}