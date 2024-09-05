using System.Collections.Generic;
using TMPro;
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

        /// <summary>�����L���O���肵���X�R�A�f�[�^</summary>
        [SerializeField] ScoreRankingData m_scoreRanking;
        /// <summary>�����L���O��\�������郊�X�g</summary>
        [SerializeField] List<TextMeshProUGUI> m_rankingTextList;

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

            view.OnCloseButtonClicked += OnCloseButtonClicked;
            view.OnOpenRankingList += OnOpenRankingList;
            view.Initialize();
        }

        /// <summary>
        /// ����{�^���������ꂽ���̏���
        /// </summary>
        private void OnCloseButtonClicked()
        {
            model.CloseRankiing(m_ranking);
            SoundManager.Instance.PlaySE("Close");
        }

        /// <summary>
        /// �����L���O���J��
        /// </summary>
        private void OnOpenRankingList()
        {
            model.OnOpenRankingList(m_scoreRanking, m_rankingTextList);
        }
    }
}

