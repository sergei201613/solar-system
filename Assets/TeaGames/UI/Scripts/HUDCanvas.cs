using TeaGames.SolarSystem.Interaction;
using UnityEngine;

namespace TeaGames.SolarSystem.UI
{
    public class HUDCanvas : MonoBehaviour
    {
        [SerializeField]
        private BodyInfoPanel _bodyInfoPanel;

        private Focuser _focuser;

        private void Awake()
        {
            _focuser = FindObjectOfType<Focuser>();
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
            _bodyInfoPanel.Open();            
        }

        private void OnUnfocused()
        {
            _bodyInfoPanel.Close();            
        }
    }
} 