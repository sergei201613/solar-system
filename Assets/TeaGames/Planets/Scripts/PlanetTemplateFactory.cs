using SimpleKeplerOrbits;
using UnityEngine;

namespace TeaGames.SolarSystem.Planets
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
        [SerializeField]
		private KeplerOrbitMover earchMoonBarycenter;
        [SerializeField]
		private KeplerOrbitMover plutoCharonBarycenter;
        [SerializeField]
		private KeplerOrbitMover solarSystemBarycenter;
        [SerializeField]
		private KeplerOrbitMover pluto;

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
                case "Solar system barycenter":
                    return solarSystemBarycenter;
                case "Earth-Moon barycenter":
                    return earchMoonBarycenter;
                case "Pluto-Charon barycenter":
                    return plutoCharonBarycenter;
                case "Pluto":
                    return pluto;
                default:
                    hasTemplate = false;
                    return defaultBodyTemplate;
            }
        }
    }
}
