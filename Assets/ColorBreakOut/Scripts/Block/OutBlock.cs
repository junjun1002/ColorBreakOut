using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// このコンポーネントに当たったら消えるクラス
    /// </summary>
    public class OutBlock : MonoBehaviour
    {
        /// <summary>
        /// ボールが当たったらアクティブをFalseにする
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
        }
    }
}