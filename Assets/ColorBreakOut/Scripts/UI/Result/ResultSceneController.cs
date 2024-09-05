using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// タイトルシーンの処理を担当するクラス
    /// </summary>
    public class ResultSceneController : MonoBehaviour
    {
        // タイトルシーンのモデル
        private ResultSceneModel model;
        // タイトルシーンのビュー
        private ResultSceneView view;

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Awake()
        {
            model = new ResultSceneModel();
            view = FindObjectOfType<ResultSceneView>();

            view.OnReturnTitleButtonClicked += OnReturnTitleButtonClicked;
            view.OnReturnInGameButtonClicked += OnReturnInGameButtonClicked;
            view.OnUserNameInputed += OnUserNameInputed;

            view.Initialize();
        }

        /// <summary>
        /// タイトルに戻るボタンが押された時の処理
        /// </summary>
        private void OnReturnTitleButtonClicked()
        {
            model.ChangeScene(GameState.Instance.TitleState, GameManager.Instance.m_title);
            SoundManager.Instance.PlaySE("Decision");
        }

        /// <summary>
        /// ゲームに戻るボタンが押された時の処理
        /// </summary>
        private void OnReturnInGameButtonClicked()
        {
            model.ChangeScene(GameState.Instance.InGameState, GameManager.Instance.m_inGame);
            SoundManager.Instance.PlaySE("Decision");
        }

        /// <summary>
        /// ユーザー名が入力された時の処理
        /// </summary>
        private void OnUserNameInputed()
        {
            model.SetUserName(view.GetUserName());
            view.DeactiveUserNameInput();
            SoundManager.Instance.PlaySE("Save");
        }
    }
}

