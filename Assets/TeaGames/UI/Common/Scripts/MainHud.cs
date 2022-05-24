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

        private void OnFocused(IFocusable focusable)
        {
            //if (!focusable.get)
            //_bodyPanel.Open();
            //_bodyPanel.SetName
        }

        private void OnUnfocused()
        {
            _bodyPanel.Close();            
        }

        private bool ShouldShowTrainingTips()
        {
            return true;
        }
    }
} 