using UnityEngine;
using System.Collections;

namespace ColorBreakOut
{
    /// <summary>
    /// �t�B�[�o�[���[�h�̃X�e�[�g
    /// </summary>
    public class Fever : IState<GameManager>
    {
        /// <summary>
        /// �t�B�[�o�[���[�h�̏���
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(GameManager owner)
        {
            owner.StartCoroutine(FeverCoroutine(owner));
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

            // 10�b�ԑ҂�
            yield return new WaitForSeconds(10);

            // ���̏�ԂɑJ�ڂ���ꍇ�͂����ōs��
            Debug.Log("Fever Mode End");
            owner.stateMachine.ChageMachine(owner.gameState.InGameState);
        }


    }
}