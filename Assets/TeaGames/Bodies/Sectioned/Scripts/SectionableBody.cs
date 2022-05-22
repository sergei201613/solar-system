using UnityEngine;

namespace TeaGames.SolarSystem.Bodies
{
    public class SectionableBody : MonoBehaviour
    {
        [SerializeField]
        private GameObject _normalView;
        [SerializeField]
        private GameObject _sectionedView;

        public void SetSectionedViewEnabled(bool e)
        {
            _sectionedView.SetActive(e);
            _normalView.SetActive(!e);
        }
    }
}
