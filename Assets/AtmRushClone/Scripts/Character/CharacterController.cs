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
        }
    }
}