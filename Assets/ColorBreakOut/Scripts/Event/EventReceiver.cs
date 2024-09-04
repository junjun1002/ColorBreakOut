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
        protected InGameManager m_inGameManager;
        protected InGameState m_inGameState;

        private void Awake()
        {
            m_eventSystemInGame = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystemInGame>();
            m_inGameManager = InGameManager.Instance;
            m_inGameState = InGameState.Instance;
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
