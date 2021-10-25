using System.Collections.Generic;
using Asteroids.Entities.Enums;
using Asteroids.Entities.Interfaces;
using Asteroids.Interfaces;

namespace Asteroids.Entities.Factories
{
    public class EntityFactory : IEntityFactory
    {
        private readonly Dictionary<EntityTypes, IEntityFactory> _factories =
            new Dictionary<EntityTypes, IEntityFactory>();

        public void AddFactory(EntityTypes key, IEntityFactory factory)
        {
            _factories.Add(key, factory);
        }

        public void RemoveFactory(EntityTypes key)
        {
            _factories.Remove(key);
        }

        public IUpdatable Create(EntityTypes key)
        {
            return _factories.TryGetValue(key, out var factory) ? factory.Create(key) : null;
        }
    }
}