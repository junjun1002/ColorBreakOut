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
            Debug.Log("Result");
        }
    }
}