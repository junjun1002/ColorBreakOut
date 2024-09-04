using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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

        private InGameManager m_inGameManager;
        private InGameState m_inGameState;

        /// <summary>Blockにボールが衝突したときのイベント</summary>
        public void CollisionEvent(EventSystemInGame eventSystemInGame)
        {
            // フィーバーモード中は色は関係なく壊れる
            if (m_inGameManager.stateMachine.CurrentState == m_inGameState.FeverState)
            {
                m_currentLife--;
                if (m_currentLife == 0)
                {
                    // フィーバーモード中はスコアを10倍にする
                    eventSystemInGame.CurrentScore += m_blockData.Score * 10;
                    eventSystemInGame.CurrentBlock--;
                    gameObject.SetActive(false);
                }
            }
            else if (m_blockData.Color == eventSystemInGame.m_currentBallColor)  // ボールの色と同じだったら自身の色が同じなら壊れる
            {
                m_currentLife--;
                if (m_currentLife == 0)
                {
                    eventSystemInGame.CurrentCombo++;
                    eventSystemInGame.CurrentScore += m_blockData.Score * eventSystemInGame.CurrentCombo;
                    eventSystemInGame.CurrentBlock--;
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
            m_inGameManager = InGameManager.Instance;
            m_inGameState = InGameState.Instance;
        }

        private void OnEnable()
        {
            m_currentLife = m_blockData.Life;  
        }
    }
}