using UnityEngine;

namespace TeaGames.SolarSystem.Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private float _sensitivity = 5f;

        [SerializeField]
        private float _sensLerp = 20f;

        private Vector3 _targetRotation;
        private Vector3 _rotation;

        private void LateUpdate()
        {
            float x;
            float y;

            if (Input.GetMouseButton(1))
            {
                x = Input.GetAxisRaw("Mouse X");
                y = Input.GetAxisRaw("Mouse Y");
            }
            else
            {
                x = 0;
                y = 0;
            }

            _targetRotation = new(-y, x, 0);

            _rotation = Vector3.Lerp(_rotation, _targetRotation, _sensLerp * 
                Time.deltaTime);

            transform.Rotate(_sensitivity * Time.deltaTime * _rotation);

            transform.rotation = Quaternion.Euler(
                transform.eulerAngles.x, transform.eulerAngles.y, 0.0f);
        }
    }
}
