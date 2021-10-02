using Asteroids.Enums;
using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    public sealed class MeteorFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Meteor>(EnemyTypes.Meteor.ToString()));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}