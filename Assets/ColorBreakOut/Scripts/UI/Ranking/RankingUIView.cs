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

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="onCloseButtonClicked"></param>
        public void Initialize(Action onCloseButtonClicked)
        {
            m_closeButton.onClick.AddListener(() => onCloseButtonClicked?.Invoke());
        }
    }
}

