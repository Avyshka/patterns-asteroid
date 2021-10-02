using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enemy Data", fileName = "EnemyData", order = 51)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
    }
}