using TeaGames.SolarSystem.Interaction;
using UnityEngine;

namespace TeaGames.SolarSystem.Bodies
{
    public class SectionableBody : MonoBehaviour
    {
        [SerializeField]
        private Interactable _interactable;
        [SerializeField]
        private SectionedBody _sectionedBody;
        [SerializeField]
        private GameObject _normalView;
        [SerializeField]
        private GameObject _sectionedView;

        private void OnEnable()
        {
            _interactable.Focused += OnFocused;
            _interactable.Unfocused += OnUnfocused;
        }

        private void OnDisable()
        {
            _interactable.Focused -= OnFocused;
            _interactable.Unfocused -= OnUnfocused;
        }

        public void EnableSectionedView()
        {
            _normalView.SetActive(false);
            _sectionedView.SetActive(true);
            _sectionedBody.PlayAnimOpen(() => { });
        }

        public void DisableSectionedView()
        {
            _sectionedBody.PlayAnimClose(() =>
            {
                _sectionedView.SetActive(false);
                _normalView.SetActive(true);
            });
        }

        private void OnFocused()
        {
        }

        private void OnUnfocused()
        {
        }
    }
}
