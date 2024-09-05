using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// ���U���g�̃X�e�[�g
    /// </summary>
    public class Result : IState<GameManager>
    {
        /// <summary>
        /// ���U���g�̏���
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(GameManager owner)
        {
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlaySE("Result");

            /// �����L���O�ŉ��ʂ��X�R�A���Ⴂ�Ȃ烉���L���O�O
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