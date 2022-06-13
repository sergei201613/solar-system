using UnityEngine;
using SimpleKeplerOrbits.Examples;
using System;

namespace TeaGames.SolarSystem.Bodies
{
    public class BodyRotator : MonoBehaviour
    {
        [field: SerializeField]
        public float SpeedMultiplier { get; private set; } = -1;

        private TimeController _timeController;
        private float _hour;

        private void Awake()
        {
            _timeController = FindObjectOfType<TimeController>();
        }

        private void Update()
        {
            DateTime dt = _timeController.CurrentTime;

            _hour = dt.Hour;
            _hour += dt.Minute / 60f;
            _hour += dt.Second / 60f / 60f;
            _hour += dt.Millisecond / 60f / 60f / 1000f;

            float deg = 360f / 24f * _hour * SpeedMultiplier;

            transform.localEulerAngles = new Vector3(0, 0, deg);
        }
    }
}
