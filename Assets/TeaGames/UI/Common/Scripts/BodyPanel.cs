using UnityEngine;
using TMPro;

namespace TeaGames.SolarSystem.UI
{
    public class BodyPanel : Panel
    {
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _typeText;

        public void SetName(string name)
        {
            _nameText.text = name;
        }

        public void SetType(string type)
        {
            _typeText.text = type;
        }
    }
}
