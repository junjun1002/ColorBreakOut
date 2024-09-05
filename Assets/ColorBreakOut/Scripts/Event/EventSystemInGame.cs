using System;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// ゲーム中のイベントを管理するクラス
    /// </summary>
    public class EventSystemInGame : MonoBehaviour
    {
        InGameManager m_inGameManager;
        InGameState m_inGameState;

        /// <summary>スコアが変わった時のイベント</summary>
        public event Action<int> ScoreChangedEvent;
        /// <summary>コンボ数が変わった時のイベント</summary>
        public event Action<int> ComboChangedEvent;

        /// <summary>フィーバーモードが始まった時のイベント</summary>
        public event Action FeverStartEvent;
        /// <summary>フィーバーモードが終わった時のイベント</summary;
        public event Action FeverEndEvent;

        /// <summary>ゲームが終わった時のイベント</summary>
        public event Action GameEndEvent;

        /// <summary>現在のボールの色</summary>
        [SerializeField, HideInInspector] public Color m_currentBallColor;

        /// <summary>
        /// 現在のスコア
        /// </summary>
        private int m_currentScore = 0;
        public int CurrentScore
        {
            get => m_currentScore;
            set
            {
                // Blockの数が変わったらイベントを実行
                if (m_currentBlock != value)
                {
                    m_currentScore = value;
                    ScoreChangedEvent?.Invoke(m_currentScore);
                }
            }
        }

        /// <summary>現在のゲームシーン上に何個Blockがあるか</summary>
        private int m_currentBlock = 0;
        public int CurrentBlock
        {
            get => m_currentBlock;
            set
            {
                // Blockの数が変わったらイベントを実行
                if (m_currentBlock != value)
                {
                    m_currentBlock = value;
                    if (m_currentBlock == 0)
                    {
                        GameManager.Instance.m_resultScore = m_currentScore;
                        ExecuteGameEnd();
                    }
                }
            }
        }

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
                       m_inGameManager.ChangeFeverMode();
                    }
                }
            }
        }

        /// <summary>初期化処理</summary>
        private void Awake()
        {
            m_inGameManager = InGameManager.Instance;
            m_inGameState = InGameState.Instance;
        }

        /// <summary>フィーバーモードが始まった時のイベントを実行</summary>
        public void ExecuteStartFeverModeEvent()
        {
            FeverStartEvent?.Invoke();
        }

        /// <summary>フィーバーモードが終わった時のイベントを実行</summary>s
        public void ExecuteEndFeverModeEvent()
        {
            FeverEndEvent?.Invoke();
        }

        /// <summary>ゲームが終わった時のイベントを実行</summary>
        public void ExecuteGameEnd()
        {
            GameEndEvent?.Invoke();
        }
    }
}
