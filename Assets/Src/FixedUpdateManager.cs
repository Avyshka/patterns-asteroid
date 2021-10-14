using System.Collections.Generic;
using Src.Entities.Interfaces;

namespace Asteroids
{
    public class FixedUpdateManager
    {
        private readonly List<IFixedUpdatable> _updatableObjects = new List<IFixedUpdatable>();

        public void AddController(IFixedUpdatable controller)
        {
            _updatableObjects.Add(controller);
        }

        public void RemoveController(IFixedUpdatable controller)
        {
            _updatableObjects.Remove(controller);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            for (var i = _updatableObjects.Count - 1; i >= 0; i--)
            {
                _updatableObjects[i].OnFixedUpdate(deltaTime);
            }
        }
    }
}