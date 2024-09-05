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
        /// �X�^�[�g�{�^���������ꂽ���̏���
        /// </summary>
        public Action OnStartButtonClicked { get; set; }
        /// <summary>
        /// �I���{�^���������ꂽ���̏���
        /// </summary>
        public Action OnQuitButtonClicked { get; set; }
        /// <summary>
        /// �����L���O�{�^���������ꂽ���̏���
        /// </summary>
        public Action OnOpenRankingButtonClicked { get; set; }

        /// <summary>
        /// �X�^�[�g�{�^��
        /// </summary>
        [SerializeField] Button m_startButton;

        /// <summary>
        /// �����L���O���J���{�^��
        /// </summary>
        [SerializeField] Button m_openRankingButton;

        /// <summary>
        /// �I���{�^��
        /// </summary>
        [SerializeField] Button m_quitButton;

        /// <summary>
        /// ����������
        /// </summary>
        public void Initialize()
        {
            m_startButton.onClick.AddListener(() => OnStartButtonClicked?.Invoke());
            m_quitButton.onClick.AddListener(() => OnQuitButtonClicked?.Invoke());
            m_openRankingButton.onClick.AddListener(() => OnOpenRankingButtonClicked?.Invoke());
        }
    }
}

