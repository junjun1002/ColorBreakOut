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

            view.OnStartButtonClicked += OnStartButtonClicked;
            view.OnOpenRankingButtonClicked += OnOpenRankingButtonClicked;
            view.OnQuitButtonClicked += OnQuitButtonClicked;
            view.Initialize();
        }

        /// <summary>
        /// スタートボタンが押された時の処理
        /// </summary>
        private void OnStartButtonClicked()
        {
            model.ChangeScene(GameState.Instance.InGameState, GameManager.Instance.m_inGame);
            SoundManager.Instance.PlaySE("Decision");
        }

        /// <summary>
        /// ランキングボタンが押された時の処理
        /// </summary>
        private void OnOpenRankingButtonClicked()
        {
            model.OpenRanking(m_ranking);
            SoundManager.Instance.PlaySE("Decision");
        }

        /// <summary>
        /// 終了ボタンが押された時の処理
        /// </summary>
        private void OnQuitButtonClicked()
        {
            model.QuitGame();
            SoundManager.Instance.PlaySE("Decision");
        }
    }
}

