using UnityEngine;
using TMPro;

namespace ColorBreakOut
{
    /// <summary>
    /// �X�R�A�̃C�x���g�������N���X
    /// </summary>
    public class ScoreEventHandler : EventReceiver<ScoreEventHandler>
    {
        [SerializeField] public TextMeshProUGUI m_scoreText;

        /// <summary>
        /// Block����ꂽ���ɌĂ΂��C�x���g
        /// OnEnable�œo�^
        /// </summary>
        /// <param name="score"></param>
        public void OnScoreChanged(int currentScore)
        {
            m_scoreText.text = "Score : " + currentScore;
        }

        /// <summary>
        /// �C�x���g������
        /// </summary>
        protected override void OnDisable()
        {
            m_eventSystemInGame.ScoreChangedEvent -= OnScoreChanged;
            //SaveAndLoad.Instance.SaveScoreData(m_currentScore);
        }

        /// <summary>
        /// �C�x���g��o�^
        /// </summary>
        protected override void OnEnable()
        {
            m_eventSystemInGame.ScoreChangedEvent += OnScoreChanged;
            m_scoreText.text = "Score : 0";
            m_scoreText.gameObject.SetActive(true);
        }
    }
}