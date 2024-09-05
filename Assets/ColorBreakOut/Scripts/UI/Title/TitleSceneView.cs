using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorBreakOut
{
    /// <summary>
    /// タイトルシーンのUIの表示、入力を担当するクラス
    /// </summary>
    public class TitleSceneView : MonoBehaviour
    {
        /// <summary>
        /// スタートボタンが押された時の処理
        /// </summary>
        public Action OnStartButtonClicked { get; set; }
        /// <summary>
        /// 終了ボタンが押された時の処理
        /// </summary>
        public Action OnQuitButtonClicked { get; set; }
        /// <summary>
        /// ランキングボタンが押された時の処理
        /// </summary>
        public Action OnOpenRankingButtonClicked { get; set; }

        /// <summary>
        /// スタートボタン
        /// </summary>
        [SerializeField] Button m_startButton;

        /// <summary>
        /// ランキングを開くボタン
        /// </summary>
        [SerializeField] Button m_openRankingButton;

        /// <summary>
        /// 終了ボタン
        /// </summary>
        [SerializeField] Button m_quitButton;

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            m_startButton.onClick.AddListener(() => OnStartButtonClicked?.Invoke());
            m_quitButton.onClick.AddListener(() => OnQuitButtonClicked?.Invoke());
            m_openRankingButton.onClick.AddListener(() => OnOpenRankingButtonClicked?.Invoke());
        }
    }
}

