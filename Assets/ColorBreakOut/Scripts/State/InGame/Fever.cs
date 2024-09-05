using UnityEngine;
using System.Collections;

namespace ColorBreakOut
{
    /// <summary>
    /// フィーバーモードのステート
    /// </summary>
    public class Fever : IState<InGameManager>
    {
        private Coroutine m_feverCoroutine;

        /// <summary>
        /// フィーバーモードの処理
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(InGameManager owner)
        {
            SoundManager.Instance.PlayBGM("Fever");
            m_feverCoroutine = owner.StartCoroutine(FeverCoroutine(owner));
        }

        /// <summary>
        /// フィーバーモードのコルーチン
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        private IEnumerator FeverCoroutine(InGameManager owner)
        {
            // フィーバーモード開始の処理
            Debug.Log("Fever Mode Start");
            float elapsedTime = 0f;
            float duration = 10f;

            while (elapsedTime < duration)
            {
                // ここに反復処理を追加
                Debug.Log("Fever Mode Running");
                owner.m_eventSystemInGame.ExecuteStartFeverModeEvent();

                // 1フレーム待つ
                yield return null;

                elapsedTime += Time.deltaTime;
            }

            // 次の状態に遷移する
            Debug.Log("Fever Mode End");
            owner.stateMachine.ChageMachine(owner.m_inGameState.DefaultState);
            owner.m_eventSystemInGame.ExecuteEndFeverModeEvent();
            owner.StopCoroutine(m_feverCoroutine);
        }


    }
}