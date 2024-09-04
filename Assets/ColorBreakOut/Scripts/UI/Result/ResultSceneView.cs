using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorBreakOut
{
    /// <summary>
    /// ���U���g�V�[����UI�̕\���A���͂�S������N���X
    /// </summary>
    public class ResultSceneView : MonoBehaviour
    {
        /// <summary>
        /// �^�C�g���ɖ߂�{�^��
        /// </summary>
        [SerializeField] Button m_returnTitleButton;

        /// <summary>
        /// �Q�[���ɖ߂�{�^��
        /// </summary>
        [SerializeField] Button m_returnInGameButton;

        /// <summary>
        /// ����������
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

