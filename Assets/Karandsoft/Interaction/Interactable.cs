using UnityEngine;

namespace ClimbATree.InteractionSystem
{
    public class Interactable : MonoBehaviour, IFocusable, ISelectable, IInteractable
    {
        [SerializeField]
        private GameObject _selectEffect;

        public void OnFocus()
        {
        }

        public void OnInteract()
        {
        }

        public void OnSelect()
        {
            _selectEffect.SetActive(true);
        }

        public void OnUnselect()
        {
            _selectEffect.SetActive(false);
        }
    }
}
