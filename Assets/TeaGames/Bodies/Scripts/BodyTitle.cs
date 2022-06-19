using TeaGames.SolarSystem.Interaction;
using TeaGames.SolarSystem.UI;
using UnityEngine;

namespace TeaGames.SolarSystem.Bodies
{
    [RequireComponent(typeof(BodyInfo))]
    public class BodyTitle : MonoBehaviour
    {
        [SerializeField]
        private BodyTitlePanel _titlePrefab;
        [SerializeField]
        private InteractableBody _interactableBody;

        private MainHud _mainHud;
        private BodyInfo _bodyInfo;
        private BodyTitlePanel _title;
        private Camera _camera;
        private Focuser _focuser;

        private static bool IsTitlesEnabled = true;

        private const float OffsetDivider = 1.5f;

        private void Awake()
        {
            _focuser = FindObjectOfType<Focuser>();
            _mainHud = FindObjectOfType<MainHud>();
            _bodyInfo = GetComponent<BodyInfo>();
            _camera = Camera.main;

            _title = Instantiate(_titlePrefab, _mainHud.transform);
            _title.Init(_interactableBody);
            _title.Title = _bodyInfo.Name;
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                IsTitlesEnabled = !IsTitlesEnabled;

            bool canSee = !(_title.transform.position.z < 0);

            bool active = IsTitlesEnabled && !_focuser.IsFocused &&
                canSee;

            _title.gameObject.SetActive(active);

            float offset = _interactableBody.GetDistanceOffset() 
                / OffsetDivider;
            Vector3 pos = transform.position + Vector3.down * offset;

            var screenPos = _camera.WorldToScreenPoint(pos);
            _title.transform.position = screenPos;
        }
    }
}
