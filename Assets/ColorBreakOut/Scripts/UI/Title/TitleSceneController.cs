using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �^�C�g���V�[���̏�����S������N���X
    /// </summary>
    public class TitleSceneController : MonoBehaviour
    {
        // �^�C�g���V�[���̃��f��
        private TitleSceneModel model;
        // �^�C�g���V�[���̃r���[
        private TitleSceneView view;

        /// <summary>
        /// ����������
        /// </summary>
        private void Awake()
        {
            model = new TitleSceneModel();
            view = FindObjectOfType<TitleSceneView>();

            view.Initialize(OnStartButtonClicked, OnQuitButtonClicked);
        }

        /// <summary>
        /// �X�^�[�g�{�^���������ꂽ���̏���
        /// </summary>
        private void OnStartButtonClicked()
        {
            model.ChangeScene(GameState.Instance.InGameState, GameManager.Instance.m_inGame);
        }

        private void OnQuitButtonClicked()
        {
            model.QuitGame();
        }
    }
}

