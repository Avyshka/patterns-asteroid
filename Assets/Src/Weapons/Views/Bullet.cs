using System;
using Asteroids.Players.Views;
using Asteroids.Weapons.Models;
using UnityEngine;

namespace Asteroids.Weapons.Views
{
    public class Bullet : MonoBehaviour
    {
        public event Action PrepareToDestroy;

        private Rigidbody _rigidbody;
        private MoveTransform _moveTransform;

        public void Init(BulletModel model)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _moveTransform = new MoveTransform(_rigidbody, model.Speed);
        }

        public void OnUpdate(float deltaTime)
        {
            _moveTransform.Move(1, deltaTime);
        }

        private void OnBecameInvisible()
        {
            PrepareToDestroy?.Invoke();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerView>())
            {
                return;
            }

            PrepareToDestroy?.Invoke();
        }
    }
}