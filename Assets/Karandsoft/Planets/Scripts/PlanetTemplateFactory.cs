using SimpleKeplerOrbits;
using UnityEngine;

namespace ClimbATree.SolarSystem.Planets
{
    public class PlanetTemplateFactory : MonoBehaviour
    {
        public static PlanetTemplateFactory Instance { get; private set; }

        [SerializeField]
		private KeplerOrbitMover defaultBodyTemplate;
        [SerializeField]
		private KeplerOrbitMover earthTemplate;
        [SerializeField]
		private KeplerOrbitMover sunTemplate;
        [SerializeField]
		private KeplerOrbitMover mercuryTemplate;
        [SerializeField]
		private KeplerOrbitMover venusTemplate;
        [SerializeField]
		private KeplerOrbitMover marsTemplate;
        [SerializeField]
		private KeplerOrbitMover moonTemplate;
        [SerializeField]
		private KeplerOrbitMover jupiterTemplate;
        [SerializeField]
		private KeplerOrbitMover saturnTemplate;
        [SerializeField]
		private KeplerOrbitMover uranusTemplate;
        [SerializeField]
		private KeplerOrbitMover neptuneTemplate;

        private void Awake()
        {
            Instance = this; 
        }

        public KeplerOrbitMover GetTemplate(string bodyName, out bool hasTemplate)
        {
            hasTemplate = true;

            switch (bodyName)
            {
                case "Earth":
                    return earthTemplate;
                case "Sun":
                    return sunTemplate;
                case "Mercury":
                    return mercuryTemplate;
                case "Venus":
                    return venusTemplate;
                case "Mars":
                    return marsTemplate;
                case "Moon":
                    return moonTemplate;
                case "Jupiter":
                    return jupiterTemplate;
                case "Saturn":
                    return saturnTemplate;
                case "Uranus":
                    return uranusTemplate;
                case "Neptune":
                    return neptuneTemplate;
                default:
                    hasTemplate = false;
                    return defaultBodyTemplate;
            }
        }
    }
}
