using Asteroids.Enemies.Enums;
using Asteroids.Enemies.Interfaces;
using Asteroids.Pools;
using UnityEngine;

namespace Asteroids.Enemies.Factories
{
    public sealed class CometFactory : IEnemyFactory
    {
        public GameObject Create()
        {
            var enemy = ViewServices.Instance.Instantiate(Resources.Load<GameObject>(EnemyTypes.Comet.ToString()));
            return enemy;
        }
    }
}