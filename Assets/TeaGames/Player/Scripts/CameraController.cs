using TeaGames.SolarSystem.Interaction;
using UnityEngine;

namespace TeaGames.SolarSystem.Player
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField]
		private float _sensitivity = 5f;

		[SerializeField]
		private float _scrollSpeed = 1f;

		[SerializeField]
		private float _minCamDistance = -1;

		[SerializeField]
		private float _maxCamDistance = -50;

		[SerializeField]
		private float _scrollLerpSpeed = 5f;

		[SerializeField]
		private Transform _camTransform;

		[SerializeField]
		private float _moveToTargetSpeed = 5f;

		[SerializeField]
		private float _baseFocusDist = -0.2f;

		[SerializeField]
		private float _movementSpeed = 1f;

		[SerializeField]
		private float _movementBoost = 10f;

		private float _angleX;
		private float _angleY;
		private float _targetScrollPosition;
		private Focuser _focuser;

		private void Awake()
		{
			_focuser = FindObjectOfType<Focuser>();

			_targetScrollPosition = _camTransform.localPosition.z;
		}

		private void LateUpdate()
		{
			HandleRotation();
			HandleZooming();
			HandleArrowsMovement();
			UpdateMovementToTarget();
		}

		private void HandleRotation()
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

		private void HandleZooming()
		{
			var scrollDelta = Input.mouseScrollDelta.y;
			var currentPos = _camTransform.localPosition.z;

			if (scrollDelta < 0)
				_focuser.Unfocus();

			_camTransform.localPosition = new Vector3(0, 0, Mathf.Lerp(
				currentPos, _targetScrollPosition, 
				_scrollLerpSpeed * Time.deltaTime));

			if (Mathf.Approximately(scrollDelta, 0))
				return;

			_targetScrollPosition = scrollDelta < 0 ? currentPos * 
				_scrollSpeed : currentPos / _scrollSpeed;

			_targetScrollPosition = Mathf.Clamp(_targetScrollPosition, 
				_minCamDistance, _maxCamDistance);
		}

		private void UpdateMovementToTarget()
		{
			if (!_focuser.IsFocused)
				return;

			var pos = _focuser.Current.GetFocusPosition();

			transform.position = Vector3.Lerp(transform.position,
				pos, _moveToTargetSpeed * Time.deltaTime);

			var offset = _focuser.Current.GetDistanceOffset();
			_targetScrollPosition = _baseFocusDist * offset;
		}

		private void HandleArrowsMovement()
		{
			var hor = Input.GetAxis("Horizontal");
			var ver = Input.GetAxis("Vertical");

			float zoom = Mathf.Abs(_camTransform.localPosition.z);

			if (Mathf.Approximately(hor, 0) && 
				Mathf.Approximately(ver, 0))
			{
				return;
			}

			_focuser.Unfocus();

			var boost = Input.GetKey(KeyCode.LeftShift) ? _movementBoost : 1f;

			boost *= zoom;

			var speedX = hor * _movementSpeed * 2 * Time.deltaTime * boost;
			var speedY = ver * _movementSpeed * 2 * Time.deltaTime * boost;

			Vector3 normal = new(0, 1, 0);

			var right = Vector3.Cross(normal, transform.forward).normalized;
			var forward = Vector3.Cross(right, normal).normalized;

			transform.Translate(speedY * forward + speedX * right, Space.World);
		}
	}
}
