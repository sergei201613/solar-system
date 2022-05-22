using UnityEngine;

namespace TeaGames.SolarSystem.UI
{
    public class RotationTrainingTipPanel : TrainingTipPanel
    {
        private void Update()
        {
            if (Input.GetMouseButton(1))
            {
                if (Mathf.Abs(Input.GetAxisRaw("Mouse X")) > 0)
                    Complete();
            }
        }
    }
}
