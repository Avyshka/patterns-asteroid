using UnityEngine;

namespace Asteroids
{
    public interface IViewServices
    {
        GameObject Instantiate(GameObject prefab);
        void Destroy(GameObject value);
    }
}