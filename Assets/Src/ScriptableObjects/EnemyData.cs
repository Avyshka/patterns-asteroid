using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enemy Data", fileName = "EnemyData", order = 51)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float speed;
        [SerializeField] private float hp;
        [SerializeField] private float damage;
        
        public float RotationSpeed => rotationSpeed;
        public float Speed => speed;
        public float Hp => hp;
        public float Damage => damage;
    }
}