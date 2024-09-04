using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �^�C�g���V�[���̏�����S������N���X
    /// </summary>
    public class RankingUIController : MonoBehaviour
    {
        // �^�C�g���V�[���̃��f��
        private RankingUIModel model;
        // �^�C�g���V�[���̃r���[
        private RankingUIView view;

        /// <summary>
        /// �����L���OUI
        /// </summary>
        [SerializeField] GameObject m_ranking;

        /// <summary>
        /// ����������
        /// </summary>
        private void Awake()
        {
            model = new RankingUIModel();
            view = FindObjectOfType<RankingUIView>();

            if (view == null)
            {
                Debug.LogError("RankingUIView��������܂���ł���");
                return;
            }
            m_ranking.SetActive(false);
            view.Initialize(OnCloseButtonClicked);
        }

        /// <summary>
        /// ����{�^���������ꂽ���̏���
        /// </summary>
        private void OnCloseButtonClicked()
        {
            model.CloseRankiing(m_ranking);
        }
    }
}

