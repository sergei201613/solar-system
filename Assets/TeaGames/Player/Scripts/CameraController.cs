using UnityEngine;

namespace TeaGames.SolarSystem.Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private float _sensitivity = 5f;

        [SerializeField]
        private float _sensLerp = 20f;

        private float _angleX;
        private float _angleY;

        private void LateUpdate()
        {
            float dx;
            float dy;

            if (Input.GetMouseButton(1))
            {
                dx = Input.GetAxisRaw("Mouse X");
                dy = Input.GetAxisRaw("Mouse Y");
            }
            else
            {
                dx = 0;
                dy = 0;
            }

            _angleY -= _sensitivity * Time.deltaTime * dy;
            _angleX += _sensitivity * Time.deltaTime * dx;

            transform.rotation = Quaternion.AngleAxis(
                _angleY, Vector3.right);

            transform.Rotate(Vector3.up * _angleX, Space.World);
        }
    }
}
