using TMPro;
using UnityEngine;

namespace TeaGames.SolarSystem.UI
{
    public class BodyListItem : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        private Transform _bodyTransform;
        private BodiesPanel _bodiesPanel;

        public void Init(BodiesPanel panel, Transform bodyTransform, 
            string text)
        {
            _bodiesPanel = panel;
            _bodyTransform = bodyTransform;
            _text.text = text;
        }

        public void FocusOnBody()
        {
            _bodiesPanel.Focus(_bodyTransform);
        }
    }
}
