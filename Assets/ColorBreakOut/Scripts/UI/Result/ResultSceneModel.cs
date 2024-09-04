using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public void SetUserName(string userName)
        {
            GameManager.Instance.RankingUpdate(userName);
            SaveManager.Instance.SaveScriptableObject(GameManager.Instance.m_scoreRankingData);
        }
    }
}