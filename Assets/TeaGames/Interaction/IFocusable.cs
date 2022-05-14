using UnityEngine;

namespace TeaGames.SolarSystem.Interaction
{
    public interface IFocusable
    {
        public void OnFocus();

        public void OnUnfocus();

        public float GetDistanceOffset();

        public Vector3 GetFocusPosition();
    }
}
