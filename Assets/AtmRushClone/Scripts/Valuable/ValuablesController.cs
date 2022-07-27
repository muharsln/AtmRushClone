using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace AtmRushClone.Valuable
{
    public class ValuablesController : MonoBehaviour
    {
        public static ValuablesController Instance { get; private set; }

        public List<GameObject> moneyList = new List<GameObject>();

        [SerializeField] private Transform _moneyParent;

        private void Awake()
        {
            Instance = this;
        }

        public void StackMoney(GameObject other, int index)
        {
            moneyList.Add(other);
            other.transform.parent = _moneyParent;
            Vector3 newPos = moneyList[index].transform.localPosition;
            newPos.y = other.transform.localPosition.y;
            newPos.z += 1f;
            other.transform.localPosition = newPos;
            StartCoroutine(MoneyScaler());
        }

        IEnumerator MoneyScaler()
        {
            for (int i = moneyList.Count - 1; i > 0; i--)
            {
                int index = i;
                moneyList[index].transform.DOScale(Vector3.one * 1.5f, 0.1f).OnComplete(()
                => moneyList[index].transform.DOScale(Vector3.one, 0.1f));
                yield return new WaitForSeconds(0.05f);
            }
        }

        public void MoveMoneyElement()
        {
            for (int i = 1; i < moneyList.Count; i++)
            {
                Vector3 pos = moneyList[i].transform.localPosition;
                pos.x = moneyList[i - 1].transform.localPosition.x;
                moneyList[i].transform.DOLocalMove(pos, 0.15f);
            }
        }

        public void MoveOrigin()
        {
            for (int i = 1; i < moneyList.Count; i++)
            {
                Vector3 pos = moneyList[i].transform.localPosition;
                pos.x = moneyList[0].transform.localPosition.x;
                moneyList[i].transform.DOLocalMove(pos, 0.35f);
            }
        }
    }
}