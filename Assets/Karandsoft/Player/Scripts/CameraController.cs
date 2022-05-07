using ClimbATree.InteractionSystem;
using UnityEngine;

namespace ClimbATree.SolarSystem.Player
{
	public class CameraController : MonoBehaviour
	{
        public float DistanceToSun => Mathf.Abs(_camTransform.localPosition.z);

        [SerializeField]
		private float _focusDistance = -0.2f;

        [SerializeField]
		private float _arrowsMovementSpeedMlt = 1f;

		[SerializeField]
		private float _arrowsMovementBoostMlt = 10f;

		[SerializeField]
		private float _rotationSpeedMlt = 1f;

		[SerializeField]
		private Transform _camTransform;

		[SerializeField]
		private float _scrollSpeed = 1f;

		[SerializeField]
		private float _minCamDistance = -50f;

		[SerializeField]
		private float _maxCamDistance = -1f;

		[SerializeField]
        private float _scrollLerpSpeed = 5f;

		[SerializeField]
        private float _moveToTargetSpeed = 5f;

		[SerializeField]
		private Vector3 _slideMotionNormal = new Vector3(0, 1, 0);

		private Transform _transform;

		private bool _isRMBPressed;
        private float _targetScrollPosition;
        private Transform _target;
		private Focuser _focuser;

        private void Awake()
		{
			_transform = transform;
			_focuser = FindObjectOfType<Focuser>();

			_targetScrollPosition = _camTransform.localPosition.z;
		}

        private void OnEnable()
        {
			_focuser.Focused += OnFocused;
        }
        private void OnDisable()
        {
			_focuser.Focused -= OnFocused;
        }

        private void OnFocused(Transform focusable)
        {
			_target = focusable;
        }

        private void Update()
		{
			UpdateMovementToTarget();
			UpdateArrowsMovement();
			UpdateMouseRotation();
			UpdateZoom();
		}

        private void UpdateMovementToTarget()
        {
			if (!_target)
				return;

			transform.position = Vector3.Lerp(transform.position, 
				_target.position, _moveToTargetSpeed * Time.deltaTime);

			_targetScrollPosition = _focusDistance;
        }

        private void UpdateArrowsMovement()
		{
			var horizontal = Input.GetAxis("Horizontal");
			var vertical = Input.GetAxis("Vertical");

			if (Mathf.Approximately(horizontal, 0) && Mathf.Approximately(vertical, 0)) return;

			_target = null;

			var boostMlt = Input.GetKey(KeyCode.LeftShift) ? _arrowsMovementBoostMlt : 1f;
			var speedX = horizontal * _arrowsMovementSpeedMlt * 2 * Time.deltaTime * boostMlt;
			var speedY = vertical * _arrowsMovementSpeedMlt * 2 * Time.deltaTime * boostMlt;
			var right = Vector3.Cross(_slideMotionNormal, _transform.forward).normalized;
			var forward = Vector3.Cross(right, _slideMotionNormal).normalized;
			transform.Translate(speedY * forward + speedX * right, Space.World);
		}

		private void UpdateMouseRotation()
		{
			if (Input.GetMouseButton(1))
			{
				if (!_isRMBPressed)
				{
					_isRMBPressed = true;
					OnRMBPressStart();
				}

				OnRMBUpdate();
			}
			else
			{
				if (_isRMBPressed)
				{
					_isRMBPressed = false;
					OnRMBRelease();
				}
			}
		}

		private void OnRMBUpdate()
		{
			var axisX = Input.GetAxis("Mouse X");
			var axisY = Input.GetAxis("Mouse Y");
			if (Mathf.Approximately(axisX, 0) && Mathf.Approximately(axisY, 0)) return;

			var scaleMlt = _rotationSpeedMlt * 50 * Time.deltaTime;
			var rotX = axisX * 5 * scaleMlt;
			var rotY = axisY * 5 * scaleMlt;
			var rotation = Quaternion.LookRotation(_transform.forward, _slideMotionNormal);
			var delta = Quaternion.Euler(rotY, -rotX, 0);
			_transform.localRotation = rotation * delta;
		}

		private void OnRMBPressStart()
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Confined;
		}

		private void OnRMBRelease()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}

		private void UpdateZoom()
		{
			var scrollDelta = Input.mouseScrollDelta.y;
			var currentPos = _camTransform.localPosition.z;

			if (scrollDelta < 0)
				_target = null;

			_camTransform.localPosition = new Vector3(
				0, 0, Mathf.Lerp(currentPos, _targetScrollPosition, _scrollLerpSpeed * Time.deltaTime));

			if (Mathf.Approximately(scrollDelta, 0))
				return;

			_targetScrollPosition = scrollDelta < 0 ? currentPos * _scrollSpeed : currentPos / _scrollSpeed;
			_targetScrollPosition = Mathf.Clamp(_targetScrollPosition, _minCamDistance, _maxCamDistance);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, transform.position + transform.forward * 10);
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(transform.position, transform.position + transform.up * 2);

			var r = Vector3.Cross(_slideMotionNormal, transform.forward).normalized;
			var f = Vector3.Cross(r, _slideMotionNormal).normalized;

			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(transform.position - r * 1, transform.position + r * 1);
			Gizmos.color = Color.green;
			Gizmos.DrawLine(transform.position, transform.position + f * 4);

			Gizmos.color = Color.red;
			Gizmos.DrawLine(_camTransform.position, _camTransform.position + _camTransform.forward * 6f);
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(_camTransform.position, _camTransform.position + _camTransform.up * 1.2f);

			Gizmos.color = Color.gray;
			Gizmos.DrawLine(new Vector3(), _slideMotionNormal * 10);
		}
	}
}