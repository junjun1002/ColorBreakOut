using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorBreakOut
{
    /// <summary>
    /// リザルトシーンのUIの表示、入力を担当するクラス
    /// </summary>
    public class ResultSceneView : MonoBehaviour
    {
        /// <summary>
        /// タイトルに戻るボタン
        /// </summary>
        [SerializeField] Button m_returnTitleButton;

        /// <summary>
        /// ゲームに戻るボタン
        /// </summary>
        [SerializeField] Button m_returnInGameButton;

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="onReturnTitleButtonClicked"></param>
        /// <param name="onReturnInGameButtonClicked"></param>
        public void Initialize(Action onReturnTitleButtonClicked, Action onReturnInGameButtonClicked)
        {
            m_returnTitleButton.onClick.AddListener(() => onReturnTitleButtonClicked?.Invoke());
            m_returnInGameButton.onClick.AddListener(() => onReturnInGameButtonClicked?.Invoke());
        }
    }
}

