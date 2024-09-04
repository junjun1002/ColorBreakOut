using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorBreakOut
{
    /// <summary>
    /// �^�C�g���V�[����UI�̕\���A���͂�S������N���X
    /// </summary>
    public class TitleSceneView : MonoBehaviour
    {
        /// <summary>
        /// �X�^�[�g�{�^��
        /// </summary>
        [SerializeField] Button m_startButton;

        /// <summary>
        /// �I���{�^��
        /// </summary>
        [SerializeField] Button m_quitButton;

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="onStartButtonClicked"></param>
        public void Initialize(Action onStartButtonClicked, Action onQuitButtonClicked)
        {
            m_startButton.onClick.AddListener(() => onStartButtonClicked?.Invoke());
            m_quitButton.onClick.AddListener(() => onQuitButtonClicked?.Invoke());
        }
    }
}

