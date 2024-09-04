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
        /// スタートボタン
        /// </summary>
        [SerializeField] Button m_startButton;

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="onStartButtonClicked"></param>
        public void Initialize(Action onStartButtonClicked)
        {
            m_startButton.onClick.AddListener(() => onStartButtonClicked?.Invoke());
        }
    }
}

