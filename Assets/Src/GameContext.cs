using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    public class GameContext: MonoBehaviour
    {
        private IUpdatable _playerController;

        private void Start()
        {
            _playerController = new PlayerController(new PlayerModel(), FindObjectOfType<PlayerView>());
        }

        private void Update()
        {
            _playerController.OnUpdate(Time.deltaTime);
        }
    }
}