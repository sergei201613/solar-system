using UnityEngine;
using TMPro;
using TeaGames.SolarSystem.Interaction;
using TeaGames.SolarSystem.Bodies;

namespace TeaGames.SolarSystem.UI
{
    public class BodyPanel : Panel
    {
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _typeText;

        private Focuser _focuser;

        private void Awake()
        {
            _focuser = FindObjectOfType<Focuser>();
        }

        public void EnableSectionedView()
        {
            if (_focuser.Current == null)
                return;

            if (_focuser.Current.TryGetComponent<SectionableBody>
                (out var body))
            {
                body.EnableSectionedView();
            }
        }

        public void DisableSectionedView()
        {
            if (_focuser.Current == null)
                return;

            if (_focuser.Current.TryGetComponent<SectionableBody>
                (out var body))
            {
                body.DisableSectionedView();
            }
        }

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
