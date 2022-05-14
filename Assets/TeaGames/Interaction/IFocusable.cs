using UnityEngine;

namespace TeaGames.InteractionSystem
{
    public interface IFocusable
    {
        public void OnFocus();

        public void OnUnfocus();

        public float GetDistanceOffset();

        public Vector3 GetFocusPosition();
    }
}
