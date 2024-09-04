using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// タイトルシーンの機能を担当するクラス
    /// </summary>
    public class TitleSceneModel
    {
        /// <summary>
        /// シーンの切り替え
        /// </summary>
        /// <param name="nextScene"></param>
        public void ChangeScene(IState<GameManager> state, string sceneName)
        {
            GameManager.Instance.ChangeScene(state, sceneName);
        }
    }
}