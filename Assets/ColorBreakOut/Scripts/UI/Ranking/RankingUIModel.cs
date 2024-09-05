using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// rランキングUIの機能を担当するクラス
    /// </summary>
    public class RankingUIModel
    {
        /// <summary>
        /// ランキングを閉じる
        /// </summary>
        public void CloseRankiing(GameObject ranking)
        {
            ranking.SetActive(false);
        }

        /// <summary>
        /// ランキングを開く
        /// </summary>
        /// <param name="scoreRankingData"></param>
        /// <param name="rankingTextList"></param>
        public void OnOpenRankingList(ScoreRankingData scoreRankingData, List<TextMeshProUGUI> rankingTextList)
        {
            // ランキングを表示
            for (int i = 0; i < scoreRankingData.RankingList.Count; i++)
            {
                Debug.Log(scoreRankingData.RankingList[i].userName + " : " + scoreRankingData.RankingList[i].score);
                rankingTextList[i].text = (i + 1).ToString() + " : " + scoreRankingData.RankingList[i].userName + " : " + scoreRankingData.RankingList[i].score.ToString();
            }
        }
    }
}