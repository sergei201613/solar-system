using UnityEngine;
using TMPro;
using TeaGames.SolarSystem.Interaction;
using UnityEngine.EventSystems;
using TeaGames.SolarSystem.Bodies;

namespace TeaGames.SolarSystem.UI
{
    public class BodyTitlePanel : Interactable, IPointerEnterHandler,
        IPointerExitHandler, IPointerClickHandler
    {
        public string Title
        {
            get
            {
                return _title.text;
            }
            set
            {
                _title.text = value;
            }
        }

        [SerializeField]
        private TextMeshProUGUI _title;
        [SerializeField]
        private Color _normalColor;
        [SerializeField]
        private Color _selectedColor;

        private Focuser _focuser;
        private InteractableBody _interactableBody;

        private void Awake()
        {
            _focuser = FindObjectOfType<Focuser>();
            _title.color = _normalColor;
        }

        public void Init(InteractableBody body)
        {
            _interactableBody = body;
        }

        private void OnEnable()
        {
            if (_interactableBody == null)
                return;

            _interactableBody.Focused += OnFocus;
            _interactableBody.Unfocused += OnUnfocus;
        }

        private void OnDisable()
        {
            _interactableBody.Focused -= OnFocus;
            _interactableBody.Unfocused -= OnUnfocus;

            OnUnselect();
            OnUnfocus();
        }

        public override void OnSelect()
        {
            _title.color = _selectedColor;
        }

        public override void OnUnselect()
        {
            _title.color = _normalColor;
        }

        public override void OnFocus()
        {
            _title.enabled = false;
        }

        public override void OnUnfocus()
        {
            _title.enabled = true;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnSelect();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnUnselect();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _focuser.Focus(_interactableBody);
        }
    }
}
