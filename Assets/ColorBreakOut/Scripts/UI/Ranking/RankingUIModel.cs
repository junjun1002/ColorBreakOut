using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// r�����L���OUI�̋@�\��S������N���X
    /// </summary>
    public class RankingUIModel
    {
        /// <summary>
        /// �����L���O�����
        /// </summary>
        public void CloseRankiing(GameObject ranking)
        {
            ranking.SetActive(false);
        }

        /// <summary>
        /// �����L���O���J��
        /// </summary>
        /// <param name="scoreRankingData"></param>
        /// <param name="rankingTextList"></param>
        public void OnOpenRankingList(ScoreRankingData scoreRankingData, List<TextMeshProUGUI> rankingTextList)
        {
            // �����L���O��\��
            for (int i = 0; i < scoreRankingData.RankingList.Count; i++)
            {
                Debug.Log(scoreRankingData.RankingList[i].userName + " : " + scoreRankingData.RankingList[i].score);
                rankingTextList[i].text = (i + 1).ToString() + " : " + scoreRankingData.RankingList[i].userName + " : " + scoreRankingData.RankingList[i].score.ToString();
            }
        }
    }
}