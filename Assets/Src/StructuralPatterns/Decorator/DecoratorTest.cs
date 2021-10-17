using UnityEngine;

namespace Decorator
{
    public sealed class DecoratorTest : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        private ModificationMuffler _modificationMuffler;
        private ModificationAim _modificationAim;

        private void Start()
        {
            _modificationMuffler = new ModificationMuffler();
            _modificationAim = new ModificationAim();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _modificationAim.ApplyModification(_weapon);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                _modificationMuffler.ApplyModification(_weapon);
            }
        }
    }
}