using Asteroids.UI.ScreenComponents;
using UnityEngine;

namespace Asteroids.UI.Screens
{
    public sealed class GameScreen : MonoBehaviour
    {
        [SerializeField] private ScoreComponent _score;
        [SerializeField] private DestroyedEnemiesComponent _destroyedEnemies;

        private readonly string[] _formats =
        {
            "{0:0.0}",
            "{0:#,0,.0 K}",
            "{0:#,0,,.0 M}",
            "{0:#,0,,,.0 B}",
            "{0:#,0,,,,.0 T}",
            "{0:#,0,,,,,.0 q}",
            "{0:#,0,,,,,,.0 Q}",
            "{0:#,0,,,,,,,.0 s}",
            "{0:#,0,,,,,,,,.0 S}",
            "{0:#,0,,,,,,,,,.0 O}",
            "{0:#,0,,,,,,,,,,.0 N}",
            "{0:#,0,,,,,,,,,,,.0 d}",
            "{0:#,0,,,,,,,,,,,,.0 U}"
        };

        public void UpdateScore(float score)
        {
            _score.UpdateText($"Score: {ToSmall(score)}");
        }

        public void UpdateDestroyedEnemy(float comets, float asteroids, float meteors)
        {
            _destroyedEnemies.UpdateText($"/ Comets: {comets} / Asteroids: {asteroids} / Meteors: {meteors} /");
        }

        private string ToSmall(float number)
        {
            var stringNumber = $"{number:F20}";
            char[] separators = {',', '.'};
            var numberParts = stringNumber.Split(separators);
            var numberSize = (numberParts[0].Length - 1) / 3;
            var format = _formats[numberSize] ?? _formats[_formats.Length - 1];

            return string.Format(format, number);
        }
    }
}