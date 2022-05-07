using UnityEngine;

namespace TeaGames.InteractionSystem
{
    public class Focuser : MonoBehaviour
    {
        public event System.Action<Transform> Focused;

		[SerializeField]
        private LayerMask _focusLayers;

        private Camera _camera;

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

            focusable.OnFocus();
            Focused?.Invoke(hit.transform);
        }
    }
}
