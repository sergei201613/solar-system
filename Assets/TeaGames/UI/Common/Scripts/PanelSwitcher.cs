using UnityEngine;

namespace TeaGames.SolarSystem.UI
{
    public class PanelSwitcher : MonoBehaviour
    {
        private Panel _current;
        private Panel _last;

        public void Close()
        {
            if (_current == null)
                return;

            _current.Close();
            _current = null;
        }

        public void Switch(Panel panel)
        {
            _current?.Close();
            _last = _current;
            _current = panel;
            _current.Open();
        }

        public void Back()
        {
            if (_last == null)
                return;

            Switch(_last);
        }
    }
}
