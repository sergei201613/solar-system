using UnityEngine;

namespace TeaGames.SolarSystem.Common
{
    public class Scaler : MonoBehaviour
    {
        [field: Range(0, 1)]
        [field: SerializeField]
        public float Value { get; private set; }
    }
}
