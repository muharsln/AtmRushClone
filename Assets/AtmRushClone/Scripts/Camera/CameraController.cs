using UnityEngine;

namespace AtmRushClone.Camera
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Follow")]
        [SerializeField] private Transform _target;
        [SerializeField] private float _lerpSpeed = 1f;

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void LateUpdate()
        {
            if (GameManager.Instance.gameStat == GameManager.GameStat.Play)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition,
                    new Vector3(_target.localPosition.x, transform.localPosition.y,
                    transform.localPosition.z), _lerpSpeed * Time.deltaTime);
            }
        }

        public void CameraAnimFalse() => _animator.enabled = false;

        public void CameraRotateTrue() => _animator.SetBool("Rotate", true);
    }
}