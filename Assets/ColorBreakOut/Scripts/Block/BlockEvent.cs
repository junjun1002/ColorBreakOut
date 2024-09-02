using System.Collections;
using System.Collections.Generic;
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

        public void CollisionEvent(EventSystemInGame eventSystemInGame)
        {
            m_currentLife--;
            if (m_currentLife == 0)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            m_currentLife = m_blockData.Life;
        }
    }
}