using UnityEngine;
using TMPro;

namespace ColorBreakOut
{
    /// <summary>
    /// スコアのイベントを扱うクラス
    /// </summary>
    public class ScoreEventHandler : EventReceiver<ScoreEventHandler>
    {
        [SerializeField] public TextMeshProUGUI m_scoreText;

        float m_currentScore = 0;

        /// <summary>
        /// Blockが壊れた時に呼ばれるイベント
        /// OnEnableで登録
        /// </summary>
        /// <param name="score"></param>
        public void BreakBlockEvent(int score)
        {
            // フィーバーモード中はスコアを10倍にする
            if (m_inGameManager.stateMachine.CurrentState == m_inGameState.FeverState) m_currentScore += score * 10;
            else m_currentScore += score * m_eventSystemInGame.CurrentCombo;

            m_scoreText.text = "Score : " + m_currentScore;
        }

        /// <summary>
        /// イベントを解除
        /// </summary>
        protected override void OnDisable()
        {
            m_eventSystemInGame.BreackBlockScoreEvent -= BreakBlockEvent;
            //SaveAndLoad.Instance.SaveScoreData(m_currentScore);
        }

        /// <summary>
        /// イベントを登録
        /// </summary>
        protected override void OnEnable()
        {
            m_currentScore = 0;
            m_eventSystemInGame.BreackBlockScoreEvent += BreakBlockEvent;
            m_scoreText.text = "Score : 0";
            m_scoreText.gameObject.SetActive(true);
        }
    }
}