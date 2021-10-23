using System;
using Asteroids.Enemies.Controllers;
using Asteroids.Entities.Enums;

namespace Asteroids.Entities.Entities.Enemies.Observers
{
    public class ObserverDestroyedEnemies
    {
        public event Action<float, float, float> AddDestroyedEnemy;

        private float _comets;
        private float _asteroids;
        private float _meteors;

        public void Add(EnemyController enemyController)
        {
            enemyController.AddDestroyedEnemy += UpdateDestroyedEnemy;
        }

        public void Remove(EnemyController enemyController)
        {
            enemyController.AddDestroyedEnemy -= UpdateDestroyedEnemy;
        }

        private void UpdateDestroyedEnemy(EntityTypes type)
        {
            switch (type)
            {
                case EntityTypes.Comet:
                    _comets++;
                    break;
                case EntityTypes.Asteroid:
                    _asteroids++;
                    break;
                case EntityTypes.Meteor:
                    _meteors++;
                    break;
            }

            AddDestroyedEnemy?.Invoke(_comets, _asteroids, _meteors);
        }
    }
}