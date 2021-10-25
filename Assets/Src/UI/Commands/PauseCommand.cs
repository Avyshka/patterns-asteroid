using UnityEngine;

namespace Asteroids.UI.Commands
{
    public sealed class PauseCommand : Command
    {
        private readonly GameObject _screen;

        public PauseCommand(GameObject screen)
        {
            _screen = screen;
        }

        public override void Execute()
        {
            if (Succeeded)
            {
                Undo();
            }
            else
            {
                _screen.SetActive(true);
                Time.timeScale = 0.0f;
                base.Execute();
            }
        }

        public override void Undo()
        {
            _screen.SetActive(false);
            Time.timeScale = 1.0f;
            base.Undo();
        }
    }
}