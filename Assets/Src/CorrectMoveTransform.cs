using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    public class CorrectMoveTransform : ICorrectMove
    {
        private readonly Rigidbody _rigidbody;

        private readonly float _halfHeightAtDepth = float.PositiveInfinity;
        private readonly float _halfWidthAtDepth = float.PositiveInfinity;

        public CorrectMoveTransform(Rigidbody rigidbody, float additionalFar = 0)
        {
            _rigidbody = rigidbody;

            var camera = Camera.main;
            if (camera)
            {
                var halfFieldOfView = camera.fieldOfView * 0.5f * Mathf.Deg2Rad;
                _halfHeightAtDepth = (camera.farClipPlane + additionalFar) * Mathf.Tan(halfFieldOfView);
                _halfWidthAtDepth = camera.aspect * _halfHeightAtDepth;
            }
        }

        public void CorrectMove()
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