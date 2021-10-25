using System;
using Asteroids.UI;
using UnityEngine;

namespace Asteroids
{
    public class GameContext : MonoBehaviour
    {
        private GameScene _gameScene;

        private void Start()
        {
            var canvas = FindObjectOfType<Canvas>();
            var ui = new UserInterface(canvas);
            
            _gameScene = new GameScene(ui);
            _gameScene.Start();
        }

        private void Update()
        {
            _gameScene.OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _gameScene.OnFixedUpdate(Time.deltaTime);
        }
    }
}