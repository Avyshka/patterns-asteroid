using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;

        public float Speed => _moveImplementation.Speed;
        public float RotationSpeed => _rotationImplementation.RotationSpeed;

        public Ship(IMove moveImplementation, IRotation rotationImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
        }

        public void Move(float vertical, float deltaTime)
        {
            _moveImplementation.Move(vertical, deltaTime);
        }

        public void Rotate(float horizontal, float deltaTime)
        {
            _rotationImplementation.Rotate(horizontal, deltaTime);
        }
        
        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }
        
        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}