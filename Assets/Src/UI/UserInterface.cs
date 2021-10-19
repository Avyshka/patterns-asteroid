using Asteroids.UI.Commands;
using UnityEngine;

namespace Asteroids.UI
{
    public sealed class UserInterface
    {
        private readonly Commands.Command _pauseCommand;

        private GameObject _gameScreen;
        private GameObject _pauseScreen;

        public UserInterface(Component canvas)
        {
            CreateScreens(canvas);

            _pauseScreen.SetActive(false);

            _pauseCommand = new PauseCommand(_pauseScreen);
        }

        private void CreateScreens(Component canvas)
        {
            _gameScreen = Object.Instantiate(
                Resources.Load<GameObject>("GameScreen"),
                canvas.transform
            );
            _pauseScreen = Object.Instantiate(
                Resources.Load<GameObject>("PauseScreen"),
                canvas.transform
            );
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