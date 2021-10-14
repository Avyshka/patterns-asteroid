using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    public class MoveTransform : IMove
    {
        private readonly Rigidbody _rigidbody;

        public float Speed { get; protected set; }

        public MoveTransform(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            Speed = speed;
        }

        public void Move(float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _rigidbody.velocity = _rigidbody.transform.forward * vertical * speed;
        }
    }
}