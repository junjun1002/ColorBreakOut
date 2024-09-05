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
        /// �����L���O
        /// </summary>
        [SerializeField] GameObject m_ranking;

        /// <summary>
        /// ����������
        /// </summary>
        private void Awake()
        {
            model = new TitleSceneModel();
            view = FindObjectOfType<TitleSceneView>();

            view.OnStartButtonClicked += OnStartButtonClicked;
            view.OnOpenRankingButtonClicked += OnOpenRankingButtonClicked;
            view.OnQuitButtonClicked += OnQuitButtonClicked;
            view.Initialize();
        }

        /// <summary>
        /// �X�^�[�g�{�^���������ꂽ���̏���
        /// </summary>
        private void OnStartButtonClicked()
        {
            model.ChangeScene(GameState.Instance.InGameState, GameManager.Instance.m_inGame);
            SoundManager.Instance.PlaySE("Decision");
        }

        /// <summary>
        /// �����L���O�{�^���������ꂽ���̏���
        /// </summary>
        private void OnOpenRankingButtonClicked()
        {
            model.OpenRanking(m_ranking);
            SoundManager.Instance.PlaySE("Decision");
        }

        /// <summary>
        /// �I���{�^���������ꂽ���̏���
        /// </summary>
        private void OnQuitButtonClicked()
        {
            model.QuitGame();
            SoundManager.Instance.PlaySE("Decision");
        }
    }
}

