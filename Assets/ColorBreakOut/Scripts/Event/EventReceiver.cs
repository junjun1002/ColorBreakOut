using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// イベントを購読する抽象クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EventReceiver<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected EventSystemInGame m_eventSystemInGame;

        private void Awake()
        {
            m_eventSystemInGame = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystemInGame>(); 
        }

        /// <summary>
        /// イベントを登録
        /// </summary>
        protected abstract void OnEnable();

        /// <summary>
        /// イベントを解除
        /// </summary>
        protected abstract void OnDisable();
    }
}
