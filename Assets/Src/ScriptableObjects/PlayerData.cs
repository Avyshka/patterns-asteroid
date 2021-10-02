using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Player Data", fileName = "PlayerData", order = 52)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float speed;
        [SerializeField] private float acceleration;
        [SerializeField] private float hp;

        public float RotationSpeed => rotationSpeed;
        public float Speed => speed;
        public float Acceleration => acceleration;
        public float Hp => hp;
    }
}