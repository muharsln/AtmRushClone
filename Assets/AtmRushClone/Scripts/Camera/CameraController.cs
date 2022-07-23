using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtmRushClone.Camera
{
    public class CameraController : MonoBehaviour
    {
        public static CameraController Instance { get; private set; }

        private Animator _camAnim;

        private void Awake()
        {
            Instance = this;
            _camAnim = GetComponent<Animator>();
        }

        public void CameraAnimActive()
        {
            _camAnim.SetBool("Rotate", true);
        }
    }
}