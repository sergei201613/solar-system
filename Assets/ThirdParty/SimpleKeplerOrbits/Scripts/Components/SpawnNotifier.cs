using System;
using UnityEngine;

namespace SimpleKeplerOrbits
{
	/// <summary>
	/// Component for tracking kepler bodies creation.
	/// </summary>
	public class SpawnNotifier : MonoBehaviour
	{
		private static event Action<KeplerOrbitMover> OnGlobalBodySpawnedEvent;

		public event Action<KeplerOrbitMover> OnBodySpawnedEvent;

		private void Awake()
		{
			OnGlobalBodySpawnedEvent += OnGlobalNotify;
		}

		private void OnDestroy()
		{
			OnGlobalBodySpawnedEvent -= OnGlobalNotify;
		}

		private void OnGlobalNotify(KeplerOrbitMover b)
		{
			OnBodySpawnedEvent?.Invoke(b);
		}

		public void NotifyBodySpawned(KeplerOrbitMover b)
		{
			OnGlobalBodySpawnedEvent?.Invoke(b);
		}
	}
}