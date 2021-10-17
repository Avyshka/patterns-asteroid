using UnityEngine;


namespace Decorator
{
    public sealed class Weapon : MonoBehaviour
    {
        [SerializeField] private float _shotVolume;
        [SerializeField] private Transform _placeForMuffler;
        [SerializeField] private Transform _placeForAim;

        public void SetShotVolume(float shotVolume)
        {
            _shotVolume -= shotVolume;
        }

        public Vector3 MufflerPosition()
        {
            return _placeForMuffler.position;
        }
        
        public Vector3 AimPosition()
        {
            return _placeForAim.position;
        }
    }
}
