using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ColorBreakOut
{
    /// <summary>
    /// リザルトシーンのUIの表示、入力を担当するクラス
    /// </summary>
    public class ResultSceneView : MonoBehaviour
    {
        /// <summary>
        /// タイトルに戻るボタンが押された時の処理
        /// </summary>
        public Action OnReturnTitleButtonClicked { get; set; }
        /// <summary>
        /// ゲームに戻るボタンが押された時の処理
        /// </summary>
        public Action OnReturnInGameButtonClicked { get; set; }
        /// <summary>
        /// ユーザー名が入力された時の処理
        /// </summary>
        public Action OnUserNameInputed { get; set; }

        /// <summary>
        /// タイトルに戻るボタン
        /// </summary>
        [SerializeField] Button m_returnTitleButton;
        
        /// <summary>
        /// ゲームに戻るボタン
        /// </summary>
        [SerializeField] Button m_returnInGameButton;

        [SerializeField] TMP_InputField m_userNameInput;
        [SerializeField] TextMeshProUGUI m_rankingUpdateText;

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            m_returnTitleButton.onClick.AddListener(() => OnReturnTitleButtonClicked?.Invoke());
            m_returnInGameButton.onClick.AddListener(() => OnReturnInGameButtonClicked?.Invoke());

            if (GameManager.Instance.m_isRanking)
            {
                ActiveUserNameInput();  
            }
            else
            {
                DeactiveUserNameInput();  
            }

            m_userNameInput.onEndEdit.AddListener((value) => OnUserNameInputed?.Invoke());
        }

        /// <summary>
        /// ユーザー名の入力を有効にする
        /// </summary>
        public void ActiveUserNameInput()
        {
            m_userNameInput.gameObject.SetActive(true);
            m_rankingUpdateText.gameObject.SetActive(true); 
            m_returnTitleButton.gameObject.SetActive(false);
            m_returnInGameButton.gameObject.SetActive(false);
        }

        /// <summary>
        /// ユーザー名の入力を無効にする
        /// </summary>
        public void DeactiveUserNameInput()
        {
            m_userNameInput.gameObject.SetActive(false);
            m_rankingUpdateText.gameObject.SetActive(false);
            m_returnTitleButton.gameObject.SetActive(true);
            m_returnInGameButton.gameObject.SetActive(true);
        }

        /// <summary>
        /// ユーザー名を取得する
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            return m_userNameInput.text;
        }
    }
}

