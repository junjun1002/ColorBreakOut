namespace ColorBreakOut
{
    /// <summary>
    /// タイトルシーンの機能を担当するクラス
    /// </summary>
    public class ResultSceneModel
    {
        /// <summary>
        /// シーンの切り替え
        /// </summary>
        public void ChangeScene(IState<GameManager> state, string sceneName)
        {
            GameManager.Instance.ChangeScene(state, sceneName);
        }

        /// <summary>
        /// ユーザーネームを登録する
        /// </summary>
        /// <param name="userName"></param>
        public void SetUserName(string userName)
        {
            GameManager.Instance.RankingUpdate(userName);
            SaveManager.Instance.SaveScriptableObject(GameManager.Instance.m_scoreRankingData);
        }
    }
}