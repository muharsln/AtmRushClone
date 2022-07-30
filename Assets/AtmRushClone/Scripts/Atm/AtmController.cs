using TMPro;
using DG.Tweening;
using UnityEngine;

namespace AtmRushClone.Atm
{
    public class AtmController : MonoBehaviour
    {
        public static AtmController Instance { get; private set; }
        [SerializeField] private TextMeshPro _atmText;

        private int _atmAmount;

        private void Awake()
        {
            Instance = this;
        }
        public void AtmCounterChanging(int value)
        {
            _atmAmount += value;
            _atmText.text = _atmAmount.ToString();
        }

        public void SmoothMoveDown()
        {
            transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.1f).OnComplete(() =>
            {
                transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f);
                transform.DOLocalMoveY(-3f, 0.2f);
            });
        }
    }
}