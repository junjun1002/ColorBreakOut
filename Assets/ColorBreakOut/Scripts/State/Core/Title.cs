using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// タイトルのステート
    /// </summary>
    public class Title : IState<GameManager>
    {
        /// <summary>
        /// タイトルの処理
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(GameManager owner)
        {
            Debug.Log("Title");
            SaveManager.Instance.LoadScriptableObject(owner.m_scoreRankingData);
        }
    }
}