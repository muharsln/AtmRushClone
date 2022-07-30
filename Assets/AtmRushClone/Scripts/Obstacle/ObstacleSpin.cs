using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtmRushClone.Obstacle
{
    public class ObstacleSpin : MonoBehaviour
    {
        [SerializeField] private float _spinSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.up * _spinSpeed * Time.deltaTime);
        }
    }
}