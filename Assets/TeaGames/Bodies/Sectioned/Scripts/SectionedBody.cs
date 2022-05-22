using UnityEngine;

namespace TeaGames.SolarSystem.Bodies
{
    public class SectionedBody : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private bool _isForwardAnimDir = true;
        private System.Action _finishAction;

        public void PlayAnimOpen(System.Action onFinish)
        {
            _finishAction = onFinish;
            _isForwardAnimDir = true;

            _animator.SetFloat("SpeedMlt", 1);
            _animator.Play("Open");
        }

        public void PlayAnimClose(System.Action onFinish)
        {
            _finishAction = onFinish;
            _isForwardAnimDir = false;

            _animator.SetFloat("SpeedMlt", -1);
            _animator.Play("Open");
        }

        public void Anim_OnStart()
        {
            if (!_isForwardAnimDir)
            {
                _finishAction?.Invoke();     
                _animator.SetFloat("SpeedMlt", 0);
            }
        }

        public void Anim_OnEnd()
        {
            if (_isForwardAnimDir)
            {
                _finishAction?.Invoke();     
                _animator.SetFloat("SpeedMlt", 0);
            }
        }
    }
}
