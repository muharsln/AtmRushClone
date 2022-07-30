using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace AtmRushClone.Valuables
{
    public class ValuableController : MonoBehaviour
    {
        public static ValuableController Instance { get; private set; }

        public List<GameObject> valuableList = new List<GameObject>();

        [SerializeField] private Transform _valuablesParent;
        [SerializeField] private Transform _disableValuablesParent;

        private void Awake()
        {
            Instance = this;
        }

        public void StackMoney(GameObject other, int index)
        {
            valuableList.Add(other);
            other.transform.parent = _valuablesParent;
            Vector3 newPos = valuableList[index].transform.localPosition;
            newPos.y = other.transform.localPosition.y;
            newPos.z += 1f;
            other.transform.localPosition = newPos;
            StartCoroutine(MoneyScaler());
        }

        public void UnstackMoney(GameObject other)
        {
            valuableList.Remove(other);
            other.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(ParentNull(other));
        }

        private IEnumerator ParentNull(GameObject other)
        {
            yield return new WaitForSeconds(0.2f);
            other.transform.parent = _disableValuablesParent;
        }

        private IEnumerator MoneyScaler()
        {
            for (int i = valuableList.Count - 1; i > 0; i--)
            {
                int index = i;
                valuableList[index].transform.DOScale(Vector3.one * 1.5f, 0.1f).OnComplete(()
                => valuableList[index].transform.DOScale(Vector3.one, 0.1f));
                yield return new WaitForSeconds(0.05f);
            }
        }

        public void MoveMoneyElement()
        {
            for (int i = 1; i < valuableList.Count; i++)
            {
                Vector3 pos = valuableList[i].transform.localPosition;
                pos.x = valuableList[i - 1].transform.localPosition.x;
                valuableList[i].transform.DOLocalMove(pos, 0.15f);
            }
        }

        public void MoveOrigin()
        {
            for (int i = 1; i < valuableList.Count; i++)
            {
                Vector3 pos = valuableList[i].transform.localPosition;
                pos.x = valuableList[0].transform.localPosition.x;
                valuableList[i].transform.DOLocalMove(pos, 0.35f);
            }
        }
    }
}