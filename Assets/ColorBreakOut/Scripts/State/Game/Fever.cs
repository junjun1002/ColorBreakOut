using UnityEngine;
using System.Collections;

namespace ColorBreakOut
{
    /// <summary>
    /// �t�B�[�o�[���[�h�̃X�e�[�g
    /// </summary>
    public class Fever : IState<GameManager>
    {
        private Coroutine m_feverCoroutine;

        /// <summary>
        /// �t�B�[�o�[���[�h�̏���
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(GameManager owner)
        {
            m_feverCoroutine = owner.StartCoroutine(FeverCoroutine(owner));
        }

        /// <summary>
        /// �t�B�[�o�[���[�h�̃R���[�`��
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        private IEnumerator FeverCoroutine(GameManager owner)
        {
            // �t�B�[�o�[���[�h�J�n�̏���
            Debug.Log("Fever Mode Start");
            owner.m_eventSystemInGame.ExecuteStartFeverModeEvent();

            // 10�b�ԑ҂�
            yield return new WaitForSeconds(10);

            owner.m_eventSystemInGame.ExecuteEndFeverModeEvent();

            // ���̏�ԂɑJ�ڂ���ꍇ�͂����ōs��
            Debug.Log("Fever Mode End");
            owner.stateMachine.ChageMachine(owner.gameState.InGameState);
            owner.StopCoroutine(m_feverCoroutine);
        }


    }
}