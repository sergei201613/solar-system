using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TeaGames.SolarSystem.Interaction
{
    public class Focuser : MonoBehaviour
    {
        public event Action<Interactable> Focused;
        public event Action Unfocused;

        public bool IsFocused => _current != null;

        public Interactable Current => _current;

        [SerializeField]
        private LayerMask _focusLayers;

        private Camera _camera;
        private Interactable _current;

        private void Awake()
        {
            _camera = Camera.main; 
        }

        private void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out var hit, 2000f, _focusLayers);

            if (!hit.collider)
                return;

            if (!hit.collider.TryGetComponent<Interactable>(out var focusable))
                return;

            if (!Input.GetMouseButtonDown(0))
                return;

            Focus(focusable);
        }

        public void Focus(Interactable focusable)
        {
            if (_current != null)
                Unfocused?.Invoke();

            _current?.OnUnfocus();
            _current = focusable;
            _current.OnFocus();

            Focused?.Invoke(_current);
        }

        public void Unfocus()
        {
            _current?.OnUnfocus();
            _current = null;

            Unfocused?.Invoke();
        }
    }
}
