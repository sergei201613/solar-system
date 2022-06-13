using UnityEngine;
using SimpleKeplerOrbits.Examples;
using System;

namespace TeaGames.SolarSystem.Bodies
{
    public class BodyRotator : MonoBehaviour
    {
        [field: SerializeField]
        public double SpeedMultiplier { get; private set; } = -1;

        private TimeController _timeController;
        private double _deg = 0;

        private void Awake()
        {
            _timeController = FindObjectOfType<TimeController>();
        }

        private void Update()
        {
            DateTime dt = _timeController.CurrentTime;

            double hour = dt.Year * 365 * 24;
            hour += dt.DayOfYear * 24;
            hour += dt.Hour;
            hour += dt.Minute / 60d;
            hour += dt.Second / 60d / 60d;
            hour += dt.Millisecond / 60d / 60d / 1000d;

            _deg = (360d / (24d * SpeedMultiplier)) * hour;
            _deg %= 360d;

            transform.localEulerAngles = new Vector3(0, 0, (float)_deg);
        }
    }
}
