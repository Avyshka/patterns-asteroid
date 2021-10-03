using System;
using Asteroids.Enemies.Models;
using Asteroids.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Enemies.Views
{
    public abstract class Enemy : MonoBehaviour
    {
        public event Action PrepareToDestroy;
        
        private IHealth _health;
        private Rigidbody _rigidbody;
        private CorrectMoveTransform _correctMove;

        public void Init(EnemyModel model)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(Vector3.forward * model.Speed);
            _rigidbody.angularVelocity += Random.Range(-model.RotationSpeed, model.RotationSpeed) * Vector3.right;
           
            _correctMove = new CorrectMoveTransform(_rigidbody, 5);
            _health = new Health(model.Hp);
        }
        
        public void OnUpdate(float deltaTime)
        {
            if (_health.IsDead)
            {
                return;
            }
            _correctMove.CorrectMove();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_health.IsDead)
            {
                return;
            }

            _health.AddDamage();
            if (_health.IsDead)
            {
                PrepareToDestroy?.Invoke();
            }
        }
    }
}