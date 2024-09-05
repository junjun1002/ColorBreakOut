using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ColorBreakOut
{
    /// <summary>
    /// ���U���g�V�[����UI�̕\���A���͂�S������N���X
    /// </summary>
    public class ResultSceneView : MonoBehaviour
    {
        /// <summary>
        /// �^�C�g���ɖ߂�{�^���������ꂽ���̏���
        /// </summary>
        public Action OnReturnTitleButtonClicked { get; set; }
        /// <summary>
        /// �Q�[���ɖ߂�{�^���������ꂽ���̏���
        /// </summary>
        public Action OnReturnInGameButtonClicked { get; set; }
        /// <summary>
        /// ���[�U�[�������͂��ꂽ���̏���
        /// </summary>
        public Action OnUserNameInputed { get; set; }

        /// <summary>
        /// �^�C�g���ɖ߂�{�^��
        /// </summary>
        [SerializeField] Button m_returnTitleButton;
        
        /// <summary>
        /// �Q�[���ɖ߂�{�^��
        /// </summary>
        [SerializeField] Button m_returnInGameButton;

        /// <summary>
        /// �X�R�A�\���e�L�X�g
        /// </summary>
        [SerializeField] TextMeshProUGUI m_scoreText;

        /// <summary>
        /// ���[�U�[���̓��͗�
        /// </summary>
        [SerializeField] TMP_InputField m_userNameInput;
        /// <summary>
        /// �����L���O�X�V�e�L�X�g
        /// </summary>
        [SerializeField] TextMeshProUGUI m_rankingUpdateText;

        /// <summary>
        /// ����������
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
        /// ���[�U�[���̓��͂�L���ɂ���
        /// </summary>
        public void ActiveUserNameInput()
        {
            m_userNameInput.gameObject.SetActive(true);
            m_rankingUpdateText.gameObject.SetActive(true); 
            m_returnTitleButton.gameObject.SetActive(false);
            m_returnInGameButton.gameObject.SetActive(false);
            m_scoreText.gameObject.SetActive(false);
        }

        /// <summary>
        /// ���[�U�[���̓��͂𖳌��ɂ���
        /// </summary>
        public void DeactiveUserNameInput()
        {
            m_userNameInput.gameObject.SetActive(false);
            m_rankingUpdateText.gameObject.SetActive(false);
            m_returnTitleButton.gameObject.SetActive(true);
            m_returnInGameButton.gameObject.SetActive(true);
            m_scoreText.gameObject.SetActive(true);
        }

        /// <summary>
        /// ���[�U�[�����擾����
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            return m_userNameInput.text;
        }

        public void SetScoreText(int score)
        {
            m_scoreText.text = "Score : " + score.ToString();
        }
    }
}

