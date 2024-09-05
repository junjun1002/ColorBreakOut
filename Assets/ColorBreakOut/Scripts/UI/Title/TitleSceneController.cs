using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// タイトルシーンの処理を担当するクラス
    /// </summary>
    public class TitleSceneController : MonoBehaviour
    {
        // タイトルシーンのモデル
        private TitleSceneModel model;
        // タイトルシーンのビュー
        private TitleSceneView view;

        /// <summary>
        /// ランキング
        /// </summary>
        [SerializeField] GameObject m_ranking;

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Awake()
        {
            model = new TitleSceneModel();
            view = FindObjectOfType<TitleSceneView>();

            view.Initialize(OnStartButtonClicked, OnQuitButtonClicked, OnOpenRankingButtonClicked);
        }

        /// <summary>
        /// スタートボタンが押された時の処理
        /// </summary>
        private void OnStartButtonClicked()
        {
            model.ChangeScene(GameState.Instance.InGameState, GameManager.Instance.m_inGame);
            SoundManager.Instance.PlaySE("Decision");
        }

        private void OnOpenRankingButtonClicked()
        {
            model.OpenRanking(m_ranking);
            SoundManager.Instance.PlaySE("Decision");
        }

        private void OnQuitButtonClicked()
        {
            model.QuitGame();
            SoundManager.Instance.PlaySE("Decision");
        }
    }
}

