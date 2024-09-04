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

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="onCloseButtonClicked"></param>
        public void Initialize(Action onCloseButtonClicked)
        {
            m_closeButton.onClick.AddListener(() => onCloseButtonClicked?.Invoke());
        }
    }
}

