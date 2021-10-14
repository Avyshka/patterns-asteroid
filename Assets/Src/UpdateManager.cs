using System.Collections.Generic;
using Asteroids.Interfaces;
using Asteroids.Pools;

namespace Asteroids
{
    public class UpdateManager
    {
        private readonly List<IUpdatable> _updatableObjects = new List<IUpdatable>();

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
                }
                else
                {
                    c.OnUpdate(deltaTime);
                }
            }
        }
    }
}