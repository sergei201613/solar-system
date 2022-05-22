using UnityEngine;

namespace TeaGames.SolarSystem.Interaction
{
    public class Interactable : MonoBehaviour, IFocusable, ISelectable, 
        IInteractable
    {
        public event System.Action Focused;
        public event System.Action Unfocused;

        [SerializeField]
        private float _outlinePower = 15f;
        [SerializeField]
        private float _ditherDistance = 1f;
        [SerializeField]
        private MeshRenderer[] _renderers;
        [SerializeField]
        private Transform _distanceOffsetObject;

        // Only one of focusables can be focused.
        private static IFocusable _currentFocusable = null;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public float GetDistanceOffset()
        {
            return _distanceOffsetObject.transform.localScale.x;
        }

        public Vector3 GetFocusPosition()
        {
            return transform.position;
        }

        public void OnFocus()
        {
            _currentFocusable = this;
            SetOutlineStrength(0f);

            Focused?.Invoke();
        }

        public void OnUnfocus()
        {
            _currentFocusable = null;

            Unfocused?.Invoke();
        }

        public void OnInteract()
        {
        }

        public void OnSelect()
        {
            if (_currentFocusable == (IFocusable)this)
                return;

            SetOutlineStrength(_outlinePower);
        }

        public void OnUnselect()
        {
            SetOutlineStrength(0f);
        }

        private void SetDitherStrength(float strength)
        {
            foreach (var renderer in _renderers)
            {
                renderer.material.SetFloat("_Dither", strength);
            }
        }

        private void SetOutlineStrength(float strength)
        {
            foreach (var renderer in _renderers)
            {
                renderer.material.SetFloat("_OutlineStrength", strength);
            }
        }
    }
}
