using Asteroids.UI.Commands;
using Asteroids.UI.Screens;
using UnityEngine;

namespace Asteroids.UI
{
    public sealed class UserInterface
    {
        private readonly Commands.Command _pauseCommand;

        private GameScreen _gameScreen;
        private GameObject _pauseScreen;

        private float _scores;

        public UserInterface(Component canvas)
        {
            CreateScreens(canvas);

            _pauseScreen.SetActive(false);

            _pauseCommand = new PauseCommand(_pauseScreen);
        }

        private void CreateScreens(Component canvas)
        {
            var gameScreenPrefab = GameObject.Instantiate(
                Resources.Load<GameObject>("GameScreen"),
                canvas.transform
            );
            _pauseScreen = Object.Instantiate(
                Resources.Load<GameObject>("PauseScreen"),
                canvas.transform
            );

            _gameScreen = gameScreenPrefab.GetComponent<GameScreen>();
        }

        public void UpdateScores(float score)
        {
            _scores += score;
            _gameScreen.UpdateScore(_scores);
        }

        public void UpdateDestroyedEnemy(float comets, float asteroids, float meteors)
        {
            _gameScreen.UpdateDestroyedEnemy(comets, asteroids, meteors);
        }

        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pauseCommand.Execute();
            }
        }
    }
}