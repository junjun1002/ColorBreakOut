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
        }
    }
}