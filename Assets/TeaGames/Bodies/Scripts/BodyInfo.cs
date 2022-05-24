using UnityEngine;

namespace TeaGames.SolarSystem.Bodies
{
    public class BodyInfo : MonoBehaviour
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public string Type { get; private set; }
    }
}
