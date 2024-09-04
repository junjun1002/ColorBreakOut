using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// リザルトのステート
    /// </summary>
    public class Result : IState<GameManager>
    {
        /// <summary>
        /// リザルトの処理
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(GameManager owner)
        {
            Debug.Log("Result");
        }
    }
}