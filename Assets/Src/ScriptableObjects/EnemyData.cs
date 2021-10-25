using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enemy Data", fileName = "EnemyData", order = 51)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float speedMin;
        [SerializeField] private float speedMax;
        [SerializeField] private float hp;
        [SerializeField] private float damage;
        [SerializeField] private float score;

        public float RotationSpeed => rotationSpeed;
        public float SpeedMin => speedMin;
        public float SpeedMax => speedMax;
        public float Hp => hp;
        public float Damage => damage;
        public float Score => score;
    }
}