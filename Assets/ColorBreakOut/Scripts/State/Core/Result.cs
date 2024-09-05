using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// リザルトのステート
    /// </summary>
    public class Result : IState<GameManager>
    {
        /// <summary>
        /// リザルトの処理
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(GameManager owner)
        {
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlaySE("Result");

            /// ランキング最下位よりスコアが低いならランキング外
            if (owner.m_scoreRankingData.RankingList[4].score >= owner.m_resultScore)
            {
                owner.m_isRanking = false;
                return;
            }
            else
            {
                owner.m_isRanking = true;
            }
        }
    }
}