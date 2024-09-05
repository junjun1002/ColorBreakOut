using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// Blockを管理するクラス
    /// </summary>
    public class BlockEvent : MonoBehaviour, IEventCollision
    {
        /// <summary>Blockのデータを持っているScriptableObject</summary>
        [SerializeField] BlockData m_blockData;

        private InGameManager m_inGameManager;
        private InGameState m_inGameState;

        /// <summary>Blockにボールが衝突したときのイベント</summary>
        public void CollisionEvent(EventSystemInGame eventSystemInGame)
        {
            // フィーバーモード中は色は関係なく壊れる
            if (m_inGameManager.stateMachine.CurrentState == m_inGameState.FeverState)
            {
                // フィーバーモード中はスコアを10倍にする
                eventSystemInGame.CurrentScore += m_blockData.Score * 10;
                eventSystemInGame.CurrentBlock--;
                SoundManager.Instance.PlaySE("Block");
                gameObject.SetActive(false);
            }
            else if (m_blockData.Color == eventSystemInGame.m_currentBallColor)  // ボールの色と自身の色が同じなら壊れる
            {
                eventSystemInGame.CurrentCombo++;
                eventSystemInGame.CurrentScore += m_blockData.Score * eventSystemInGame.CurrentCombo;
                eventSystemInGame.CurrentBlock--;
                SoundManager.Instance.PlaySE("Block");
                gameObject.SetActive(false);
            }
            else
            {
                eventSystemInGame.CurrentCombo = 0;
            }
        }

        private void Awake()
        {
            m_inGameManager = InGameManager.Instance;
            m_inGameState = InGameState.Instance;
        }
    }
}