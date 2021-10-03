using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Bullet Data", fileName = "BulletData", order = 53)]
    public class BulletData : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        
        public float Speed => speed;
        public float Damage => damage;
    }
}