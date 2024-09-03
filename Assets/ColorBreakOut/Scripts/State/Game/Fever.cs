using UnityEngine;
using System.Collections;

namespace ColorBreakOut
{
    /// <summary>
    /// フィーバーモードのステート
    /// </summary>
    public class Fever : IState<GameManager>
    {
        private Coroutine m_feverCoroutine;

        /// <summary>
        /// フィーバーモードの処理
        /// </summary>
        /// <param name="owner"></param>
        public void OnExecute(GameManager owner)
        {
            m_feverCoroutine = owner.StartCoroutine(FeverCoroutine(owner));
        }

        /// <summary>
        /// フィーバーモードのコルーチン
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        private IEnumerator FeverCoroutine(GameManager owner)
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

            owner.m_eventSystemInGame.ExecuteEndFeverModeEvent();

            // 次の状態に遷移する場合はここで行う
            Debug.Log("Fever Mode End");
            owner.stateMachine.ChageMachine(owner.gameState.InGameState);
            owner.StopCoroutine(m_feverCoroutine);
        }


    }
}