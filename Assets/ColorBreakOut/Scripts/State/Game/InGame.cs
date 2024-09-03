using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �C���Q�[���̃X�e�[�g
    /// </summary>
    public class InGame : IState<GameManager>
    {
        /// <summary>
        /// �C���Q�[���̏���
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(GameManager owner)
        {
            Debug.Log("InGame");
            if (owner.m_eventSystemInGame == null) return;
            owner.m_eventSystemInGame.CurrentCombo = 0;
        }
    }
}