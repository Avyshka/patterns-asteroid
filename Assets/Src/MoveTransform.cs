using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    public class MoveTransform : IMove
    {
        private readonly Rigidbody _rigidbody;

        private readonly float _halfHeightAtDepth = float.PositiveInfinity;
        private readonly float _halfWidthAtDepth = float.PositiveInfinity;

        public float Speed { get; protected set; }

        public MoveTransform(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            Speed = speed;

            var camera = Camera.main;
            if (camera)
            {
                var halfFieldOfView = camera.fieldOfView * 0.5f * Mathf.Deg2Rad;
                _halfHeightAtDepth = camera.farClipPlane * Mathf.Tan(halfFieldOfView);
                _halfWidthAtDepth = camera.aspect * _halfHeightAtDepth;
            }
        }

        public void Move(float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _rigidbody.velocity = _rigidbody.transform.forward * vertical * speed;
            CorrectPositionWithCheck();
        }

        private void CorrectPositionWithCheck()
        {
            var position = _rigidbody.position;
            if (position.z > _halfWidthAtDepth)
            {
                _rigidbody.MovePosition(new Vector3(position.x, position.y, -_halfWidthAtDepth));
            }
            else if (position.z < -_halfWidthAtDepth)
            {
                _rigidbody.MovePosition(new Vector3(position.x, position.y, _halfWidthAtDepth));
            }
            else if (position.y > _halfHeightAtDepth)
            {
                _rigidbody.MovePosition(new Vector3(position.x, -_halfHeightAtDepth, position.z));
            }
            else if (position.y < -_halfHeightAtDepth)
            {
                _rigidbody.MovePosition(new Vector3(position.x, _halfHeightAtDepth, position.z));
            }
        }
    }
}