using TeaGames.SolarSystem.Interaction;
using UnityEngine;

namespace TeaGames.SolarSystem.Bodies
{
    public class Body : MonoBehaviour
    {
        public Interactable Interactable => _interactable;

        [SerializeField]
        private Interactable _interactable;
    }
}
