using UnityEngine;

namespace TeaGames.SolarSystem.UI
{
    public class TrainingTipSequence : MonoBehaviour
    {
        private int _curTipIdx = 0;
        private int _tipsCount;

        private void Awake()
        {
            _tipsCount = transform.childCount;

            if (_tipsCount <= 0)
                Debug.LogError("TrainingTipSequence doesn't contains any TrainingTipPanel!");

            var ttpObj = transform.GetChild(_curTipIdx);

            if (ttpObj.TryGetComponent<TrainingTipPanel>(out var ttp))
            {
                ttp.Open();
                ttp.Completed += OnCurTipCompleted;
            }
        }

        private void OnCurTipCompleted(TrainingTipPanel ttp)
        {
            ttp.Completed -= OnCurTipCompleted;
            ttp.Close();
        }
    }
}
