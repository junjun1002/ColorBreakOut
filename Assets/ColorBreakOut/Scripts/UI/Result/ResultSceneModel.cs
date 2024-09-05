namespace ColorBreakOut
{
    /// <summary>
    /// �^�C�g���V�[���̋@�\��S������N���X
    /// </summary>
    public class ResultSceneModel
    {
        /// <summary>
        /// �V�[���̐؂�ւ�
        /// </summary>
        public void ChangeScene(IState<GameManager> state, string sceneName)
        {
            GameManager.Instance.ChangeScene(state, sceneName);
        }

        /// <summary>
        /// ���[�U�[�l�[����o�^����
        /// </summary>
        /// <param name="userName"></param>
        public void SetUserName(string userName)
        {
            GameManager.Instance.RankingUpdate(userName);
            SaveManager.Instance.SaveScriptableObject(GameManager.Instance.m_scoreRankingData);
        }

        /// <summary>
        /// �X�R�A���擾����
        /// </summary>
        public int GetScore()
        {
            return GameManager.Instance.m_resultScore;
        }
    }
}