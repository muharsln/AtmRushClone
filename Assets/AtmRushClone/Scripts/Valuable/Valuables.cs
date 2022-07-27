using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtmRushClone.Valuable
{
    public class Valuables : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Unstacked") && !ValuablesController.Instance.moneyList.Contains(other.gameObject))
            {
                other.gameObject.tag = "Stacked";
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.AddComponent<Valuables>();
                //other.gameObject.AddComponent<Rigidbody>();
                //other.GetComponent<Rigidbody>().isKinematic = true;

                ValuablesController.Instance.StackMoney(other.gameObject, ValuablesController.Instance.moneyList.Count - 1);
            }
        }
    }
}