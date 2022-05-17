using SimpleKeplerOrbits;
using TeaGames.SolarSystem.Interaction;
using TeaGames.SolarSystem.Bodies;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace TeaGames.SolarSystem.UI
{
    public class BodiesDropdown : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown _dropdown;

        private SpawnNotifier _spawnNotifier;
        private Focuser _focuser;
        private readonly List<string> _bodyNames = new();
        private readonly List<IFocusable> _bodies = new();

        private void Awake()
        {
            _spawnNotifier = FindObjectOfType<SpawnNotifier>();
            _focuser = FindObjectOfType<Focuser>();
        }

        private void OnEnable()
        {
            _spawnNotifier.OnBodySpawnedEvent += OnBodySpawned; 
        }

        private void OnDisable()
        {
            _spawnNotifier.OnBodySpawnedEvent -= OnBodySpawned; 
        }

        public void Focus(Transform bodyTransform)
        {
            if (bodyTransform.TryGetComponent<Body>(out var body))
                _focuser.Focus(body.Interactable);
        }

        public void OnBodyChanged(int id)
        {
            _focuser.Focus(_bodies[id]);
        }

        private void OnBodySpawned(KeplerOrbitMover body)
        {
            if (!body.TryGetComponent<Body>(out var b))
                return;

            _bodyNames.Add(b.gameObject.name);
            _bodies.Add(b.Interactable);

            _dropdown.ClearOptions();
            _dropdown.AddOptions(_bodyNames);
        }
    }
}
