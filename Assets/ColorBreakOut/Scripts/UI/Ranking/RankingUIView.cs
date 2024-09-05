using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorBreakOut
{
    /// <summary>
    /// ランキングのUIの表示、入力を担当するクラス
    /// </summary>
    public class RankingUIView : MonoBehaviour
    {
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        [SerializeField] Button m_closeButton;

        public Action OnCloseButtonClicked { get; set; }

        public Action OnOpenRankingList { get; set; }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            m_closeButton.onClick.AddListener(() => OnCloseButtonClicked?.Invoke());
        }

        private void OnEnable()
        {
            OnOpenRankingList?.Invoke();
        }
    }
}

