using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtmRushClone
{
    public class GameManager : MonoBehaviour
    {
        #region Game Stat
        public enum GameStat
        {
            Start,
            Play,
            Restart,
            Finish,
            Failed
        }
        public GameStat gameStat;
        #endregion

        #region Singletom
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
        #endregion

        public void SetGameStatPlay()
        {
            gameStat = GameStat.Play;
        }
    }
}