using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    public sealed class PlayerView : MonoBehaviour, IPlayerView
    {
        private Ship _ship;
        private IHealth _health;
        private PlayerModel _model;
        private Rigidbody _rigidbody;

        public void SetModel(PlayerModel model)
        {
            _model = model;
            Init();
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Init()
        {
            var moveTransform = new AccelerationMove(_rigidbody, _model.Speed, _model.Acceleration);
            var rotation = new RotationTransform(_rigidbody, _model.RotationSpeed);
            _ship = new Ship(moveTransform, rotation);
            _health = new Health(_model.Hp);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_health.IsDead)
            {
                return;
            }
            _ship.Rotate(Input.GetAxis("Horizontal"), Time.deltaTime);
            _ship.Move(Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
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
                Destroy(gameObject);
            }
        }
    }
}