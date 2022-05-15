using SimpleKeplerOrbits;
using TeaGames.SolarSystem.Interaction;
using TeaGames.SolarSystem.Bodies;
using UnityEngine;

namespace TeaGames.SolarSystem.UI
{
    public class BodiesPanel : MonoBehaviour
    {
        [SerializeField]
        private BodyListItem _bodyListItemPrefab;
        [SerializeField]
        private Transform _itemsContent;

        private SpawnNotifier _spawnNotifier;
        private Focuser _focuser;

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

        private void OnBodySpawned(KeplerOrbitMover body)
        {
            if (!body.TryGetComponent<Body>(out var b))
                return;

            var item = Instantiate(_bodyListItemPrefab);
            item.transform.SetParent(_itemsContent);
            item.Init(this, body.transform, body.gameObject.name);
        }
    }
}
