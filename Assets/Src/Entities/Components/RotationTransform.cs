using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    internal sealed class RotationTransform : IRotation
    {
        private readonly Rigidbody _rigidbody;
        
        public float RotationSpeed { get; }

        public RotationTransform(Rigidbody transform, float rotationSpeed)
        {
            _rigidbody = transform;
            RotationSpeed = rotationSpeed;
        }

        public void Rotate(float horizontal, float deltaTime)
        {
            var speed = deltaTime * RotationSpeed;
            _rigidbody.angularVelocity = _rigidbody.transform.right * horizontal * speed;
        }
    }
}