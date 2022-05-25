using TeaGames.SolarSystem.Bodies;
using TeaGames.SolarSystem.Interaction;
using UnityEngine;

namespace TeaGames.SolarSystem.UI
{
    public class MainHud : MonoBehaviour
    {
        [field: SerializeField]
        public BodyPanel BodyPanel { get; private set; }

        [SerializeField]
        private TrainingTipSequence _trainingTipSequencePrefab;
        [SerializeField]
        private PanelSwitcher _pnlSwitcher;
        [SerializeField]
        private bool _shouldShowTrainingTips = true;

        private Focuser _focuser;

        private void Awake()
        {
            _focuser = FindObjectOfType<Focuser>();

            if (ShouldShowTrainingTips())
                Instantiate(_trainingTipSequencePrefab, transform);
        }

        private void OnEnable()
        {
            _focuser.Focused += OnFocused;
            _focuser.Unfocused += OnUnfocused;
        }

        private void OnDisable()
        {
            _focuser.Focused -= OnFocused;
            _focuser.Unfocused -= OnUnfocused;
        }

        public void EnableSectionedView()
        {
            if (_focuser.Current == null)
                return;

            if (_focuser.Current.TryGetComponent<SectionableBody>
                (out var body))
            {
                body.EnableSectionedView();
            }
        }

        public void DisableSectionedView()
        {
            if (_focuser.Current == null)
                return;

            if (_focuser.Current.TryGetComponent<SectionableBody>
                (out var body))
            {
                body.DisableSectionedView();
            }
        }

        private void OnFocused(Interactable focusable)
        {
            if (!focusable.TryGetComponent<BodyInfo>(out var info))
                return;

            _pnlSwitcher.Switch(BodyPanel);
            BodyPanel.SetName(info.Name);
            BodyPanel.SetType(info.Type);
        }

        private void OnUnfocused()
        {
            _pnlSwitcher.Close();
        }

        private bool ShouldShowTrainingTips()
        {
            return _shouldShowTrainingTips;
        }
    }
} 