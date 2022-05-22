using UnityEngine;

namespace TeaGames.SolarSystem.UI
{
    public class Panel : MonoBehaviour
    {
        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
