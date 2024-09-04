using TMPro;
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

        /// <summary>
        /// ランキングを開く
        /// </summary>
        /// <param name="ranking"></param>
        public void OpenRanking(GameObject ranking)
        {
            ranking.SetActive(true);
        }

        /// <summary>
        /// ゲームを終了する
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}