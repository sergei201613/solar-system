using TeaGames.SolarSystem.Interaction;
using UnityEngine;

namespace TeaGames.SolarSystem.Bodies
{
    public class InteractableBody : Interactable
    {
        [SerializeField]
        private float _outlinePower = 15f;
        [SerializeField]
        private MeshRenderer[] _renderers;
        [SerializeField]
        private Transform _distanceOffsetObject;

        public override void OnSelect()
        {
            if (CurrentFocusable == this)
                return;

            SetOutlineStrength(_outlinePower);
        }

        public override void OnUnselect()
        {
            SetOutlineStrength(0f);
        }

        public override void OnFocus()
        {
            CurrentFocusable = this;
            SetOutlineStrength(0f);
            InvokeFocused();
        }

        public override void OnUnfocus()
        {
            CurrentFocusable = null;
            InvokeUnfocused();
        }

        public override float GetDistanceOffset()
        {
            return _distanceOffsetObject.transform.localScale.x;
        }

        public override Vector3 GetFocusPosition()
        {
            return transform.position;
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
