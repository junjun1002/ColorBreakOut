using UnityEngine;
using TMPro;

namespace ColorBreakOut
{
    /// <summary>
    /// スコアのイベントを扱うクラス
    /// </summary>
    public class ScoreEventHandler : EventReceiver<ScoreEventHandler>
    {
        /// <summary>
        /// スコアを表示するText
        /// </summary>
        [SerializeField] public TextMeshProUGUI m_scoreText;

        /// <summary>
        /// Blockが壊れた時に呼ばれるイベント
        /// OnEnableで登録
        /// </summary>
        /// <param name="score"></param>
        public void OnScoreChanged(int currentScore)
        {
            m_scoreText.text = "Score : " + currentScore;
        }

        /// <summary>
        /// イベントを解除
        /// </summary>
        protected override void OnDisable()
        {
            m_eventSystemInGame.ScoreChangedEvent -= OnScoreChanged;
        }

        /// <summary>
        /// イベントを登録
        /// </summary>
        protected override void OnEnable()
        {
            m_eventSystemInGame.ScoreChangedEvent += OnScoreChanged;
            m_scoreText.text = "Score : 0";
            m_scoreText.gameObject.SetActive(true);
        }
    }
}