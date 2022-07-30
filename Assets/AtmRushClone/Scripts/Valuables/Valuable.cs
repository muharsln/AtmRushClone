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
            // Temas ettiðimiz objenin tagý Unstacked ise ve valuable listesinde yer almýyor ise
            if (other.CompareTag("Unstacked") && !ValuableController.Instance.valuableList.Contains(other.gameObject))
            {
                other.gameObject.tag = "Stacked";
                other.GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.AddComponent<Valuable>();
                ValuableController.Instance.StackMoney(other.gameObject, ValuableController.Instance.valuableList.Count - 1);
                Player.PlayerController.Instance.ValuableCounterChanging(1);
            }

            // Temas ettiðimiz objenin tagý Obstacle 
            if (other.CompareTag("Obstacle"))
            {
                Player.PlayerController.Instance.ValuableCounterChanging(-(_childNum + 1));
                transform.GetChild(3).transform.GetChild(_childNum).gameObject.GetComponent<ParticleSystem>().Play();
                ValuableController.Instance.UnstackMoney(gameObject);
                transform.GetChild(_childNum).gameObject.SetActive(false);
            }

            if (other.CompareTag("ATM"))
            {
                //Atm.AtmController.Instance.AtmCounterChanging(_childNum + 1);
                other.GetComponent<Atm.AtmController>().AtmCounterChanging(_childNum + 1);
                ValuableController.Instance.UnstackMoney(gameObject);
                transform.GetChild(_childNum).gameObject.SetActive(false);
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
                    Player.PlayerController.Instance.ValuableCounterChanging(1);
                }
                transform.GetChild(_childNum).gameObject.SetActive(true);
            }
        }
    }
}