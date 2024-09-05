using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �C���Q�[���̃X�e�[�g
    /// </summary>
    public class Default : IState<InGameManager>
    {
        /// <summary>
        /// �C���Q�[���̏���
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(InGameManager owner)
        {
            Debug.Log("Default");
            SoundManager.Instance.PlayBGM("InGame");

            if (owner.m_eventSystemInGame == null) return;
            owner.m_eventSystemInGame.CurrentCombo = 0;
        }
    }
}