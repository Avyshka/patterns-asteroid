using Asteroids.Enemies.Controllers;
using Asteroids.Enemies.Models;
using Asteroids.Enemies.Views;
using Asteroids.Entities.Enums;
using Asteroids.Entities.Interfaces;
using Asteroids.Interfaces;
using Asteroids.Pools;
using Asteroids.ScriptableObjects;
using UnityEngine;

namespace Asteroids.Enemies.Factories
{
    public sealed class MeteorFactory : IEntityFactory
    {
        public IUpdatable Create(EntityTypes type)
        {
            var data = Resources.Load<EnemyData>(EntityData.MeteorData.ToString());
            var enemy = ViewServices.Instance.Instantiate(Resources.Load<GameObject>(type.ToString()));
            return new EnemyController(
                new EnemyModel(data, type),
                enemy.GetComponent<Meteor>()
            );
        }
    }
}