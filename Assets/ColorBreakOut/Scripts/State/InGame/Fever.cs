using UnityEngine;
using System.Collections;

namespace ColorBreakOut
{
    /// <summary>
    /// �t�B�[�o�[���[�h�̃X�e�[�g
    /// </summary>
    public class Fever : IState<InGameManager>
    {
        private Coroutine m_feverCoroutine;

        /// <summary>
        /// �t�B�[�o�[���[�h�̏���
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(InGameManager owner)
        {
            SoundManager.Instance.PlayBGM("Fever");
            m_feverCoroutine = owner.StartCoroutine(FeverCoroutine(owner));
        }

        /// <summary>
        /// �t�B�[�o�[���[�h�̃R���[�`��
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        private IEnumerator FeverCoroutine(InGameManager owner)
        {
            // �t�B�[�o�[���[�h�J�n�̏���
            Debug.Log("Fever Mode Start");
            float elapsedTime = 0f;
            float duration = 10f;

            while (elapsedTime < duration)
            {
                // �����ɔ���������ǉ�
                Debug.Log("Fever Mode Running");
                owner.m_eventSystemInGame.ExecuteStartFeverModeEvent();

                // 1�t���[���҂�
                yield return null;

                elapsedTime += Time.deltaTime;
            }

            // ���̏�ԂɑJ�ڂ���
            Debug.Log("Fever Mode End");
            owner.stateMachine.ChageMachine(owner.m_inGameState.DefaultState);
            owner.m_eventSystemInGame.ExecuteEndFeverModeEvent();
            owner.StopCoroutine(m_feverCoroutine);
        }


    }
}