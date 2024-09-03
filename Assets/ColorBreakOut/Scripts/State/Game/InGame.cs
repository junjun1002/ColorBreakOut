using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// インゲームのステート
    /// </summary>
    public class InGame : IState<GameManager>
    {
        /// <summary>
        /// インゲームの処理
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(GameManager owner)
        {
            Debug.Log("InGame");
            if (owner.m_eventSystemInGame == null) return;
            owner.m_eventSystemInGame.CurrentCombo = 0;
        }
    }
}