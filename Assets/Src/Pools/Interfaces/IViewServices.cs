using UnityEngine;

namespace Asteroids.Pools.Interfaces
{
    public interface IViewServices
    {
        GameObject Instantiate(GameObject prefab);
        void Destroy(GameObject value);
    }
}