using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

namespace ColorBreakOut
{
    /// <summary>
    /// �����L���O�f�[�^��ێ����Ă���N���X
    /// </summary>
    public class ScoreRecorder : MonoBehaviour
    {
        /// <summary>�����L���O���肵���X�R�A�f�[�^</summary>
        [SerializeField] ScoreRankingData m_scoreRanking;
        /// <summary>�����L���O��\�������郊�X�g</summary>
        [SerializeField] List<TextMeshProUGUI> m_rankingTextList;

        /// <summary>
        /// �����L���O���X�V����֐�
        /// </summary>
        public void RankingUpdate()
        {
            var record = m_scoreRanking.RankingList.OrderByDescending((x) => x.score);

            int index = 0;
            foreach (var item in record)
            {
                m_scoreRanking.RankingList[index] = item;
                index++;
            }

            for (int i = 0; i < m_scoreRanking.RankingList.Count; i++)
            {
                Debug.Log(m_scoreRanking.RankingList[i].userName + " : " + m_scoreRanking.RankingList[i].score);
                m_rankingTextList[i].text = (i + 1).ToString() + " : " + m_scoreRanking.RankingList[i].userName + " : " + m_scoreRanking.RankingList[i].score.ToString();
            }
        }

        /// <summary>
        /// �����L���O���X�V
        /// </summary>
        private void OnEnable()
        {
            RankingUpdate();
        }
    }
}