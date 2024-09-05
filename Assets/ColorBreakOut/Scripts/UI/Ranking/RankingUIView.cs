using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorBreakOut
{
    /// <summary>
    /// �����L���O��UI�̕\���A���͂�S������N���X
    /// </summary>
    public class RankingUIView : MonoBehaviour
    {
        /// <summary>
        /// ����{�^��
        /// </summary>
        [SerializeField] Button m_closeButton;

        public Action OnCloseButtonClicked { get; set; }

        public Action OnOpenRankingList { get; set; }

        /// <summary>
        /// ����������
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

