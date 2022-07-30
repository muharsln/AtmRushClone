using UnityEngine;
using AtmRushClone.Valuables;

namespace AtmRushClone.Collect
{

    public class Collector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // Temas etti�imiz objenin tag� Unstacked ise ve valuable listesinde yer alm�yor ise
            if (other.CompareTag("Unstacked") && !ValuableController.Instance.valuableList.Contains(other.gameObject))
            {
                other.gameObject.tag = "Stacked";
                other.GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.AddComponent<Valuable>();
                ValuableController.Instance.StackMoney(other.gameObject, ValuableController.Instance.valuableList.Count - 1);
                Player.PlayerController.Instance.ValuableCounterChanging(1);
            }
        }
    }
}