using TeaGames.SolarSystem.Bodies;
using TeaGames.SolarSystem.Interaction;
using UnityEngine;

namespace TeaGames.SolarSystem.UI
{
    public class MainHud : MonoBehaviour
    {
        [SerializeField]
        private BodyPanel _bodyPanel;
        [SerializeField]
        private TrainingTipSequence _trainingTipSequencePrefab;
        [SerializeField]
        private PanelSwitcher _pnlSwitcher;

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

        private void OnFocused(Interactable focusable)
        {
            if (!focusable.TryGetComponent<BodyInfo>(out var info))
                return;

            _pnlSwitcher.Switch(_bodyPanel);
            _bodyPanel.SetName(info.Name);
            _bodyPanel.SetType(info.Type);
        }

        private void OnUnfocused()
        {
            _pnlSwitcher.Close();
        }

        private bool ShouldShowTrainingTips()
        {
            return true;
        }
    }
} 