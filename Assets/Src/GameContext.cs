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
        }

        private void Update()
        {
            _playerController.OnUpdate(Time.deltaTime);
        }
    }
}