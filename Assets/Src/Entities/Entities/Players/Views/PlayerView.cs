using System;
using Asteroids.Interfaces;
using Asteroids.Players.Models;
using Asteroids.Weapons.Views;
using UnityEngine;

namespace Asteroids.Players.Views
{
    [Serializable]
    public sealed class PlayerView : MonoBehaviour, IDamaged
    {
        public event Action<Transform> OnShoot;
        public event Action PrepareToDestroy;

        private Ship _ship;
        private CorrectMoveTransform _correctMove;
        private IHealth _health;
        private Damage _damage;
        private PlayerModel _model;
        private Rigidbody _rigidbody;

        public void Init(PlayerModel model)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _model = model;
            var moveTransform = new AccelerationMove(_rigidbody, _model.Speed, _model.Acceleration);
            var rotation = new RotationTransform(_rigidbody, _model.RotationSpeed);
            _ship = new Ship(moveTransform, rotation);
            _correctMove = new CorrectMoveTransform(_rigidbody);
            _health = new Health(_model.Hp);
            _damage = new Damage();
        }

        public void OnUpdate(float deltaTime)
        {
            if (_health.IsDead)
            {
                return;
            }

            _ship.Rotate(Input.GetAxis("Horizontal"), Time.deltaTime);
            _ship.Move(Input.GetAxis("Vertical"), Time.deltaTime);
            _correctMove.CorrectMove();

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                OnShoot?.Invoke(_rigidbody.transform);
            }
        }

        public void GetDamage(float damage)
        {
            if (_health.IsDead)
            {
                return;
            }

            _health.AddDamage(damage);
            if (_health.IsDead)
            {
                PrepareToDestroy?.Invoke();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<Bullet>())
            {
                return;
            }

            if (other.gameObject.TryGetComponent(out IDamaged damageComponent))
            {
                damageComponent.GetDamage(_damage.Hit);
            }
        }
    }
}