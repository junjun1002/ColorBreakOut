using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// タイトルシーンの処理を担当するクラス
    /// </summary>
    public class RankingUIController : MonoBehaviour
    {
        // タイトルシーンのモデル
        private RankingUIModel model;
        // タイトルシーンのビュー
        private RankingUIView view;

        /// <summary>
        /// ランキングUI
        /// </summary>
        [SerializeField] GameObject m_ranking;

        /// <summary>ランキング入りしたスコアデータ</summary>
        [SerializeField] ScoreRankingData m_scoreRanking;
        /// <summary>ランキングを表示させるリスト</summary>
        [SerializeField] List<TextMeshProUGUI> m_rankingTextList;

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Awake()
        {
            model = new RankingUIModel();
            view = FindObjectOfType<RankingUIView>();

            if (view == null)
            {
                Debug.LogError("RankingUIViewが見つかりませんでした");
                return;
            }

            m_ranking.SetActive(false);

            view.OnCloseButtonClicked += OnCloseButtonClicked;
            view.OnOpenRankingList += OnOpenRankingList;
            view.Initialize();
        }

        /// <summary>
        /// 閉じるボタンが押された時の処理
        /// </summary>
        private void OnCloseButtonClicked()
        {
            model.CloseRankiing(m_ranking);
            SoundManager.Instance.PlaySE("Close");
        }

        /// <summary>
        /// ランキングを開く
        /// </summary>
        private void OnOpenRankingList()
        {
            model.OnOpenRankingList(m_scoreRanking, m_rankingTextList);
        }
    }
}

