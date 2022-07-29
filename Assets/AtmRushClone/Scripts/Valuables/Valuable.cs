using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace AtmRushClone.Valuables
{
    public class Valuable : MonoBehaviour
    {
        private int _childNum = 0;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Unstacked") && !ValuableController.Instance.moneyList.Contains(other.gameObject))
            {
                other.gameObject.tag = "Stacked";
                other.GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.AddComponent<Valuable>();
                //other.gameObject.AddComponent<Rigidbody>();
                //other.GetComponent<Rigidbody>().isKinematic = true;

                ValuableController.Instance.StackMoney(other.gameObject, ValuableController.Instance.moneyList.Count - 1);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Passage"))
            {
                if (_childNum < 2)
                {
                    transform.GetChild(_childNum).gameObject.SetActive(false);
                    _childNum++;
                    transform.GetChild(_childNum).transform.DOScale(Vector3.one * 1.5f, 0.1f).OnComplete(()
                    => transform.GetChild(_childNum).transform.DOScale(Vector3.one, 0.1f));
                }
                transform.GetChild(_childNum).gameObject.SetActive(true);
            }
        }
    }
}