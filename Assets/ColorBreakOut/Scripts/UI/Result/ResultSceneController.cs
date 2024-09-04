using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �^�C�g���V�[���̏�����S������N���X
    /// </summary>
    public class ResultSceneController : MonoBehaviour
    {
        // �^�C�g���V�[���̃��f��
        private ResultSceneModel model;
        // �^�C�g���V�[���̃r���[
        private ResultSceneView view;

        /// <summary>
        /// ����������
        /// </summary>
        private void Awake()
        {
            model = new ResultSceneModel();
            view = FindObjectOfType<ResultSceneView>();

            view.Initialize(OnReturnTitleButtonClicked, OnReturnInGameButtonClicked, OnUserNameInputed);
        }

        /// <summary>
        /// �^�C�g���ɖ߂�{�^���������ꂽ���̏���
        /// </summary>
        private void OnReturnTitleButtonClicked()
        {
            model.ChangeScene(GameState.Instance.TitleState, GameManager.Instance.m_title);
        }

        /// <summary>
        /// �Q�[���ɖ߂�{�^���������ꂽ���̏���
        /// </summary>
        private void OnReturnInGameButtonClicked()
        {
            model.ChangeScene(GameState.Instance.InGameState, GameManager.Instance.m_inGame);
        }

        private void OnUserNameInputed()
        {
            model.SetUserName(view.m_userNameInput.text);
        }
    }
}

