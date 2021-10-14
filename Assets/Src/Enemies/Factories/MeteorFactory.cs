using Asteroids.Enemies.Controllers;
using Asteroids.Enemies.Enums;
using Asteroids.Enemies.Interfaces;
using Asteroids.Enemies.Models;
using Asteroids.Enemies.Views;
using Asteroids.Pools;
using Asteroids.ScriptableObjects;
using UnityEngine;

namespace Asteroids.Enemies.Factories
{
    public sealed class MeteorFactory : IEnemyFactory
    {
        public EnemyController Create(EnemyTypes type)
        {
            var data = Resources.Load<EnemyData>(EnemyDataEnum.MeteorData.ToString());
            var enemy = ViewServices.Instance.Instantiate(Resources.Load<GameObject>(type.ToString()));
            return new EnemyController(
                new EnemyModel(data),
                enemy.GetComponent<Meteor>()
            );
        }
    }
}