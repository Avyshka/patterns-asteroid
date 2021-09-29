using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    public sealed class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private float speed;
        [SerializeField] private float acceleration;
        [SerializeField] private float hp;
        
        [SerializeField] private Rigidbody2D bullet;
        [SerializeField] private Transform barrel;
        [SerializeField] private float force;
        
        private Camera _camera;
        private Ship _ship;
        private IHealth _health;
        private PlayerModel _model;

        public void SetModel(PlayerModel model)
        {
            _model = model;
            _model.Speed = speed;
            _model.Acceleration = acceleration;
            _model.Hp = hp;
            Init();
        }
        
        private void Init()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _model.Speed, _model.Acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            _health = new Health(_model.Hp);
        }

        public void OnUpdate(float deltaTime)
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            _ship.Move(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"),
                Time.deltaTime
            );

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
                var temAmmunition = Instantiate(bullet, barrel.position, barrel.rotation);
                temAmmunition.AddForce(barrel.up * force);
            }
        }
        
        private void OnCollisionEnter2D(Collision2D other)
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