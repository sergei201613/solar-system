using UnityEngine;
using UnityEngine.EventSystems;

namespace TeaGames.SolarSystem.Interaction
{
    public class Selector : MonoBehaviour
    {
		[SerializeField]
        private LayerMask _selectableLayers;

        private Camera _camera;
        private ISelectable _current;

        private void Awake()
        {
            _camera = Camera.main; 
        }

        private void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Unselect();
                return;
            }

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out var hit, 2000f, _selectableLayers);

            if (!hit.collider)
            {
                Unselect();
                return;
            }

            if (!hit.collider.TryGetComponent<ISelectable>(out var selectable))
            {
                Unselect();
                return;
            }

            if (selectable == _current)
                return;

            Select(selectable);
        }

        private void Select(ISelectable selectable)
        {
            _current?.OnUnselect();
            _current = selectable;
            _current.OnSelect();
        }

        private void Unselect()
        {
            _current?.OnUnselect();
            _current = null;
        }
    }
}
