using Asteroids.Enums;
using Asteroids.Interfaces;
using Asteroids.ScriptableObjects;
using UnityEngine;

namespace Asteroids
{
    public class GameContext : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        
        private IUpdatable _playerController;

        private void Start()
        {
            _playerController = new PlayerController(
                new PlayerModel(playerData),
                FindObjectOfType<PlayerView>()
            );
            
            IViewServices viewServices = new ViewServices();
            var m = viewServices.Instantiate(Resources.Load<GameObject>(EnemyTypes.Meteor.ToString()));
            m.GetComponent<Meteor>().DependencyInjectHealth(new Health(1.0f));
        }

        private void Update()
        {
            _playerController.OnUpdate(Time.deltaTime);
        }
    }
}