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
    }
}