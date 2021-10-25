using System.Collections.Generic;
using Asteroids.Enemies.Controllers;
using Asteroids.Entities.Entities.Enemies.Observers;
using Asteroids.Interfaces;
using Asteroids.Pools;

namespace Asteroids
{
    public class UpdateManager
    {
        private readonly List<IUpdatable> _updatableObjects = new List<IUpdatable>();
        private readonly ObserverDestroyedEnemies _observerDestroyedEnemies;

        public UpdateManager(ObserverDestroyedEnemies observerDestroyedEnemies)
        {
            _observerDestroyedEnemies = observerDestroyedEnemies;
        }
        
        public void AddController(IUpdatable controller)
        {
            _updatableObjects.Add(controller);
        }

        public void RemoveController(IUpdatable controller)
        {
            _updatableObjects.Remove(controller);
        }

        public void OnUpdate(float deltaTime)
        {
            for (var i = _updatableObjects.Count - 1; i >= 0; i--)
            {
                var c = _updatableObjects[i];
                if (c.IsDead)
                {
                    RemoveController(c);
                    ViewServices.Instance.Destroy(c.View);
                    if (c is EnemyController enemyController)
                    {
                        _observerDestroyedEnemies.Remove(enemyController);
                    }
                }
                else
                {
                    c.OnUpdate(deltaTime);
                }
            }
        }
    }
}