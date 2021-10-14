using UnityEngine;

namespace Asteroids
{
    public class GameContext : MonoBehaviour
    {
        private GameScene _gameScene;

        private void Start()
        {
            _gameScene = new GameScene();
            _gameScene.Start();
        }

        private void Update()
        {
            _gameScene.OnUpdate(Time.deltaTime);
        }
    }
}