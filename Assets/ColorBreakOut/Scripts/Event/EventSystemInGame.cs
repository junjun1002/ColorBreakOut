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
        public event Action<float> BleackBlockEvent;
        /// <summary>ゲームが始まる時のイベント</summary>
        public event Action GameStartEvent;
        /// <summary>ゲームが終わった時のイベント</summary>
        public event Action GameEndEvent;

        /// <summary>現在のゲームシーン上に何個Ballがあるか</summary>
        [SerializeField, HideInInspector] public int m_currentBall = 0;

        /// <summary>現在のゲームシーン上に何個Blockがあるか</summary>
        [SerializeField, HideInInspector] public int m_currentBlock = 0;

        /// <summary>ブロックが壊れた時のイベントを実行</summary>
        public void ExecuteBleakBlockEvent(float score)
        {
            BleackBlockEvent?.Invoke(score);
        }

        /// <summary>ゲームが始まる時のイベントを実行</summary>
        public void ExecuteGameStartEvent()
        {
            GameStartEvent?.Invoke();
        }

        /// <summary>ゲームが終わった時のイベントを実行</summary>
        public void ExecuteGameEnd()
        {
            GameEndEvent?.Invoke();
        }
    }
}
