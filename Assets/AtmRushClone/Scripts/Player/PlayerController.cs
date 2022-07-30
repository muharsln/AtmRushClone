using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtmRushClone.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Singleton
        public static PlayerController Instance { get; private set; }
        #endregion

        #region Variables
        [Header("Move Referance")]
        [SerializeField] private Transform _transToMove;
        [SerializeField] private float _minX, _maxX;
        private Vector3 _firsPos, _endPos, newPos;
        private float _posX;

        [Header("Forward Move")]
        [SerializeField] private float _forwardMoveSpeed;

        [Header("Chracter")]
        [SerializeField] private Animator _characterAnim;

        [Header("Score")]
        [SerializeField] private TMPro.TextMeshPro _moneyCountText;
        private int _moneyAmount;
        #endregion

        #region Awake
        private void Awake()
        {
            Instance = this;
        }
        #endregion

        #region Update
        private void Update()
        {
            if (GameManager.Instance.gameStat == GameManager.GameStat.Play)
            {
                PlayerMevement();
                CharacterSetAnim("Run", true);
            }
        }
        #endregion

        #region Player Movement
        private void PlayerMevement()
        {
            #region Move left and right
            if (Input.GetMouseButtonDown(0))
            {
                _firsPos = Input.mousePosition;
                _posX = _transToMove.localPosition.x;
            }

            if (Input.GetMouseButton(0))
            {
                _endPos = Input.mousePosition;
                newPos.x = ((_endPos.x - _firsPos.x) / (Screen.width / 30f)) + _posX;
                newPos.x = Mathf.Clamp(newPos.x, _minX, _maxX);
                _transToMove.localPosition = new Vector3(newPos.x, _transToMove.localPosition.y, _transToMove.localPosition.z);
                Valuables.ValuableController.Instance.MoveMoneyElement();
            }

            if (Input.GetMouseButtonUp(0))
            {
                Valuables.ValuableController.Instance.MoveOrigin();
            }
            #endregion

            #region Forward Movement
            transform.position += Vector3.forward * _forwardMoveSpeed * Time.deltaTime;
            #endregion
        }
        #endregion

        #region Animation
        private void CharacterSetAnim(string animName, bool animBool)
        {
            _characterAnim.SetBool(animName, animBool);
        }
        #endregion

        #region Money
        public void ValuableCounterChanging(int value)
        {
            _moneyAmount += value;
            _moneyCountText.text = _moneyAmount.ToString();
        }
        #endregion
    }
}