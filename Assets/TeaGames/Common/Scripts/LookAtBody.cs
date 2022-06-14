using SimpleKeplerOrbits;
using UnityEngine;

namespace TeaGames.SolarSystem.Bodies
{
    public class LookAtBody : MonoBehaviour
    {
        [field: SerializeField]
        public string BodyName { get; private set; }

        private SpawnNotifier _spawnNotifier;
        private Transform _target;

        private void Awake()
        {
            _spawnNotifier = FindObjectOfType<SpawnNotifier>();

            var go = GameObject.Find(BodyName);
            if (go != null)
            {
                _target = go.transform;
            }
        }

        private void OnEnable()
        {
            _spawnNotifier.OnBodySpawnedEvent += OnBodySpawned;
        }

        private void OnDisable()
        {
            _spawnNotifier.OnBodySpawnedEvent -= OnBodySpawned;
        }

        private void LateUpdate()
        {
            transform.LookAt(_target, Vector3.up);
        }

        private void OnBodySpawned(KeplerOrbitMover mover)
        {
            if (_target != null)
                return;

            if (mover.name == BodyName)
                _target = mover.transform;
        }
    }
}
