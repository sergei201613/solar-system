using UnityEngine;

namespace TeaGames.SolarSystem.Interaction
{
    public class Interactable : MonoBehaviour, IFocusable, ISelectable, IInteractable
    {
        [SerializeField]
        private GameObject _selectEffect;
        [SerializeField]
        private Transform _distanceOffsetObject;

        // Only one of focusables can be focused.
        private static IFocusable _currentFocusable = null;

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
            SetSelectionEffectEnabled(false);
        }

        public void OnUnfocus()
        {
            _currentFocusable = null;
        }

        public void OnInteract()
        {
        }

        public void OnSelect()
        {
            if (_currentFocusable == (IFocusable)this)
                return;

            SetSelectionEffectEnabled(true);
        }

        public void OnUnselect()
        {
            SetSelectionEffectEnabled(false);
        }

        private void SetSelectionEffectEnabled(bool enabled)
        {
            _selectEffect.SetActive(enabled);
        }
    }
}
