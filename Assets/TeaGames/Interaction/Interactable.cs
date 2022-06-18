using UnityEngine;

namespace TeaGames.SolarSystem.Interaction
{
    public class Interactable : MonoBehaviour, ISelectable, IInteractable
    {
        public event System.Action Focused;
        public event System.Action Unfocused;

        // Only one of focusables can be focused.
        protected static Interactable CurrentFocusable = null;

        public virtual float GetDistanceOffset() { return 0; }

        public virtual Vector3 GetFocusPosition() {  return Vector3.zero; }

        public virtual void OnFocus() { }

        public virtual void OnUnfocus() { }

        public virtual void OnInteract() { }

        public virtual void OnSelect() { }

        public virtual void OnUnselect() { }

        protected void InvokeFocused() { Focused?.Invoke(); }

        protected void InvokeUnfocused() { Unfocused?.Invoke(); }
    }
}
