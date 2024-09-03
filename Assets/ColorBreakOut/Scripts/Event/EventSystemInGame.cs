using System;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// ゲーム中のイベントを管理するクラス
    /// </summary>
    public class EventSystemInGame : MonoBehaviour
    {
        GameManager m_gameManager;
        GameState m_gameState;

        /// <summary>ブロックが壊れた時のイベント</summary>
        public event Action<int> BreackBlockScoreEvent;
        /// <summary>コンボ数が変わった時のイベント</summary>
        public event Action<int> ComboChangedEvent;

        /// <summary>フィーバーモードが始まった時のイベント</summary>
        public event Action FeverStartEvent;
        /// <summary>フィーバーモードが終わった時のイベント</summary;
        public event Action FeverEndEvent;

        //     /// <summary>ゲームが始まる時のイベント</summary>
        //     public event Action GameStartEvent;
        //     /// <summary>ゲームが終わった時のイベント</summary>
        //     public event Action GameEndEvent;

        /// <summary>現在のボールの色</summary>
        [SerializeField, HideInInspector] public Color m_currentBallColor = Color.red;

        /// <summary>現在のゲームシーン上に何個Blockがあるか</summary>
        [SerializeField, HideInInspector] public int m_currentBlock = 0;

        /// <summary>現在コンボ数</summary>
        private int m_currentCombo = 0;
        public int CurrentCombo
        {
            get => m_currentCombo;
            set
            {
                // コンボ数が変わったらイベントを実行
                if (m_currentCombo != value)
                {
                    m_currentCombo = value;
                    ComboChangedEvent?.Invoke(m_currentCombo);

                    if (m_currentCombo >= 5)
                    {
                       m_gameManager.ChangeFeverMode();
                    }
                }
            }
        }

        /// <summary>初期化処理</summary>
        private void Awake()
        {
            m_gameManager = GameManager.Instance;
            m_gameState = GameState.Instance;
        }

        /// <summary>ブロックが壊れた時のイベントを実行</summary>
        public void ExecuteBreakBlockEvent(int score)
        {
            BreackBlockScoreEvent?.Invoke(score);
        }

        /// <summary>フィーバーモードが始まった時のイベントを実行</summary>
        public void ExecuteStartFeverModeEvent()
        {
            FeverStartEvent?.Invoke();
        }

        public void ExecuteEndFeverModeEvent()
        {
            FeverEndEvent?.Invoke();
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
