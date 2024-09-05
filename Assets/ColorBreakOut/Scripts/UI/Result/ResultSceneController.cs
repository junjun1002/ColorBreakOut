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

            view.OnReturnTitleButtonClicked += OnReturnTitleButtonClicked;
            view.OnReturnInGameButtonClicked += OnReturnInGameButtonClicked;
            view.OnUserNameInputed += OnUserNameInputed;

            view.Initialize();
        }

        /// <summary>
        /// �^�C�g���ɖ߂�{�^���������ꂽ���̏���
        /// </summary>
        private void OnReturnTitleButtonClicked()
        {
            model.ChangeScene(GameState.Instance.TitleState, GameManager.Instance.m_title);
            SoundManager.Instance.PlaySE("Decision");
        }

        /// <summary>
        /// �Q�[���ɖ߂�{�^���������ꂽ���̏���
        /// </summary>
        private void OnReturnInGameButtonClicked()
        {
            model.ChangeScene(GameState.Instance.InGameState, GameManager.Instance.m_inGame);
            SoundManager.Instance.PlaySE("Decision");
        }

        /// <summary>
        /// ���[�U�[�������͂��ꂽ���̏���
        /// </summary>
        private void OnUserNameInputed()
        {
            model.SetUserName(view.GetUserName());
            view.DeactiveUserNameInput();
            SoundManager.Instance.PlaySE("Save");
        }
    }
}

