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

        public Vector3 GetRandomPosition()
        {
            var isNegative = Random.Range(0.0f, 1.0f) > 0.5f;
            var isVertical = Random.Range(0.0f, 1.0f) > 0.5f;
            float posY;
            float posZ;
            if (isVertical)
            {
                posY = isNegative ? -_halfHeightAtDepth : _halfHeightAtDepth;
                posZ = Random.Range(-_halfWidthAtDepth, _halfWidthAtDepth);
            }
            else
            {
                posY = Random.Range(-_halfHeightAtDepth, _halfHeightAtDepth);
                posZ = isNegative ? -_halfWidthAtDepth : _halfWidthAtDepth;
            }

            return new Vector3(0.0f, posY, posZ);
        }
    }
}