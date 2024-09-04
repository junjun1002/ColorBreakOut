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

        float m_currentScore = 0;

        /// <summary>
        /// Block����ꂽ���ɌĂ΂��C�x���g
        /// OnEnable�œo�^
        /// </summary>
        /// <param name="score"></param>
        public void BreakBlockEvent(int score)
        {
            // �t�B�[�o�[���[�h���̓X�R�A��10�{�ɂ���
            if (m_inGameManager.stateMachine.CurrentState == m_inGameState.FeverState) m_currentScore += score * 10;
            else m_currentScore += score * m_eventSystemInGame.CurrentCombo;

            m_scoreText.text = "Score : " + m_currentScore;
        }

        /// <summary>
        /// �C�x���g������
        /// </summary>
        protected override void OnDisable()
        {
            m_eventSystemInGame.BreackBlockScoreEvent -= BreakBlockEvent;
            //SaveAndLoad.Instance.SaveScoreData(m_currentScore);
        }

        /// <summary>
        /// �C�x���g��o�^
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