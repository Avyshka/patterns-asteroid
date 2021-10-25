using Asteroids.Weapons.Views;
using UnityEngine;

namespace Asteroids.Pools
{
    public class GameObjectBuilder
    {
        private readonly GameObject _gameObject;

        public GameObjectBuilder(PrimitiveType primitiveType = PrimitiveType.Sphere)
        {
            _gameObject = GameObject.CreatePrimitive(primitiveType);
        }

        public GameObjectBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }

        public GameObjectBuilder Rigidbody(float mass)
        {
            var component = GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            component.useGravity = false;
            return this;
        }

        public GameObjectBuilder Bullet()
        {
            GetOrAddComponent<Bullet>();
            return this;
        }

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }

        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if (!result)
            {
                result = _gameObject.AddComponent<T>();
            }

            return result;
        }
    }
}