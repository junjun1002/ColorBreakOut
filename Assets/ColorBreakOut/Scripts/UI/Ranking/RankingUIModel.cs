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
    }
}