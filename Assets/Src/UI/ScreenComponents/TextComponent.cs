using TMPro;
using UnityEngine;

namespace Asteroids.UI.ScreenComponents
{
    public class TextComponent : MonoBehaviour
    {
        private TextMeshProUGUI _textField;

        private void Awake()
        {
            _textField = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateText(string text)
        {
            _textField.text = text;
        }
    }
}