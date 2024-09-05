using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// インゲームのステート
    /// </summary>
    public class Default : IState<InGameManager>
    {
        /// <summary>
        /// インゲームの処理
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(InGameManager owner)
        {
            Debug.Log("Default");
            SoundManager.Instance.PlayBGM("InGame");

            if (owner.m_eventSystemInGame == null) return;
            owner.m_eventSystemInGame.CurrentCombo = 0;
        }
    }
}