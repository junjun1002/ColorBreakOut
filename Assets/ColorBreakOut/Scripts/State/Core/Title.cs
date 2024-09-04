using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �^�C�g���̃X�e�[�g
    /// </summary>
    public class Title : IState<GameManager>
    {
        /// <summary>
        /// �^�C�g���̏���
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(GameManager owner)
        {
            Debug.Log("Title");
            SaveManager.Instance.LoadScriptableObject(owner.m_scoreRankingData);
        }
    }
}