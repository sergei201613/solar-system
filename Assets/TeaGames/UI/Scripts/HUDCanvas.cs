using UnityEngine;

namespace TeaGames.SolarSystem.UI
{
    public class HUDCanvas : MonoBehaviour
    {
        [SerializeField]
        private GameObject _bodiesPanel;

        public void OnSelectButtonClick()
        {
            bool active = !_bodiesPanel.activeSelf;
            _bodiesPanel.SetActive(active);
        }
    }
}
