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
        /// <summary>あと何回ぶつかるとこわれるか </summary>
        private int m_currentLife;

        private GameManager m_gameManager;
        private GameState m_gameState;

        /// <summary>Blockにボールが衝突したときのイベント</summary>
        public void CollisionEvent(EventSystemInGame eventSystemInGame)
        {
            // フィーバーモード中は色は関係なく壊れる
            if (m_gameManager.stateMachine.CurrentState == m_gameState.FeverState)
            {
                m_currentLife--;
                if (m_currentLife == 0)
                {
                    eventSystemInGame.ExecuteBreakBlockEvent(m_blockData.Score);
                    gameObject.SetActive(false);
                }
            }
            else if (m_blockData.Color == eventSystemInGame.m_currentBallColor)  // ボールの色と同じだったら自身の色が同じなら壊れる
            {
                m_currentLife--;
                if (m_currentLife == 0)
                {
                    eventSystemInGame.CurrentCombo++;
                    eventSystemInGame.ExecuteBreakBlockEvent(m_blockData.Score);
                    gameObject.SetActive(false);
                }
            }
            else
            {
                eventSystemInGame.CurrentCombo = 0;
            }
        }

        private void Awake()
        {
            m_gameManager = GameManager.Instance;
            m_gameState = GameState.Instance;
        }

        private void OnEnable()
        {
            m_currentLife = m_blockData.Life;  
        }
    }
}