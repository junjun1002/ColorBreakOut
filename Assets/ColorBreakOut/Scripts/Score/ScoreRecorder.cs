using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

namespace ColorBreakOut
{
    /// <summary>
    /// ランキングデータを保持しているクラス
    /// </summary>
    public class ScoreRecorder : MonoBehaviour
    {
        /// <summary>ランキング入りしたスコアデータ</summary>
        [SerializeField] ScoreRankingData m_scoreRanking;
        /// <summary>ランキングを表示させるリスト</summary>
        [SerializeField] List<TextMeshProUGUI> m_rankingTextList;

        /// <summary>
        /// ランキングを更新する関数
        /// </summary>
        public void RankingUpdate()
        {
            // スコアの降順に並び替え
            var record = m_scoreRanking.RankingList.OrderByDescending((x) => x.score);
            int index = 0;
            foreach (var item in record)
            {
                m_scoreRanking.RankingList[index] = item;
                index++;
            }

            // ランキングを表示
            for (int i = 0; i < m_scoreRanking.RankingList.Count; i++)
            {
                Debug.Log(m_scoreRanking.RankingList[i].userName + " : " + m_scoreRanking.RankingList[i].score);
                m_rankingTextList[i].text = (i + 1).ToString() + " : " + m_scoreRanking.RankingList[i].userName + " : " + m_scoreRanking.RankingList[i].score.ToString();
            }
        }

        /// <summary>
        /// ランキングを更新
        /// </summary>
        private void OnEnable()
        {
            RankingUpdate();
        }
    }
}