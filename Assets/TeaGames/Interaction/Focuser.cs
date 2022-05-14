using UnityEngine;

namespace TeaGames.SolarSystem.Interaction
{
    public class Focuser : MonoBehaviour
    {
        public bool IsFocused => _current != null;

        public IFocusable Current => _current;

        [SerializeField]
        private LayerMask _focusLayers;

        private Camera _camera;
        private IFocusable _current;

        private void Awake()
        {
            _camera = Camera.main; 
        }

        private void Update()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out var hit, 2000f, _focusLayers);

            if (!hit.collider)
                return;

            if (!hit.collider.TryGetComponent<IFocusable>(out var focusable))
                return;

            if (!Input.GetMouseButtonDown(0))
                return;

            Focus(focusable);
        }

        public void Focus(IFocusable focusable)
        {
            _current?.OnUnfocus();
            _current = focusable;
            _current.OnFocus();
        }

        public void Unfocus()
        {
            _current?.OnUnfocus();
            _current = null;
        }
    }
}
