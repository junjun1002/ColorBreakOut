using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// ゲーム中のイベントを管理するクラス
    /// </summary>
    public class EventSystemInGame : MonoBehaviour
    {
        /// <summary>ブロックが壊れた時のイベント</summary>
        public event Action<int> BreackBlockScoreEvent;
        public event Action<int> ComboChangedEvent;
        //     /// <summary>ゲームが始まる時のイベント</summary>
        //     public event Action GameStartEvent;
        //     /// <summary>ゲームが終わった時のイベント</summary>
        //     public event Action GameEndEvent;

        /// <summary>現在のボールの色</summary>
        [SerializeField, HideInInspector] public Color m_currentBallColor = Color.red;

        /// <summary>現在のゲームシーン上に何個Blockがあるか</summary>
        [SerializeField, HideInInspector] public int m_currentBlock = 0;

        /// <summary>現在のゲームシーン上に何個Blockがあるか</summary>
        private int m_currentCombo = 0;
        public int CurrentCombo
        {
            get => m_currentCombo;
            set
            {
                if (m_currentCombo != value)
                {
                    m_currentCombo = value;
                    ComboChangedEvent?.Invoke(m_currentCombo);
                }
            }
        }

        /// <summary>ブロックが壊れた時のイベントを実行</summary>
        public void ExecuteBreakBlockEvent(int score)
        {
            BreackBlockScoreEvent?.Invoke(score);
        }

        //     /// <summary>ゲームが始まる時のイベントを実行</summary>
        //     public void ExecuteGameStartEvent()
        //     {
        //         GameStartEvent?.Invoke();
        //     }

        //     /// <summary>ゲームが終わった時のイベントを実行</summary>
        //     public void ExecuteGameEnd()
        //     {
        //         GameEndEvent?.Invoke();
        //     }
    }
}
