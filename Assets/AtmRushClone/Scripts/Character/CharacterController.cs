using System.Collections;
using UnityEngine;

namespace AtmRushClone.Character
{
    public class CharacterController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ATM"))
            {
                other.gameObject.GetComponent<Atm.AtmController>().SmoothMoveDown();
            }

            if (other.CompareTag("FinishLine"))
            {
                StartCoroutine(Stop());
            }
        }

        private IEnumerator Stop()
        {
            yield return new WaitForSeconds(1.5f);
            GameManager.Instance.gameStat = GameManager.GameStat.Finish;
        }
    }
}