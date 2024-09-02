using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorBreakOut
{
     /// <summary>
    /// Playerが動かすBarの挙動を操作するクラス
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class BarController : EventReceiver<BarController>
    {
        /// <summary>バーが動くスピード</summary>
        [SerializeField] float m_speed;
        /// <summary>ボールのオブジェクト</summary>
        [SerializeField] GameObject m_ball;
        /// <summary>ボールの射出位置</summary>
        [SerializeField] GameObject m_muzzle;

        Rigidbody2D m_rb2d;

        private void Start()
        {
            m_rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            // 水平方向の入力を検知する
            float h = Input.GetAxisRaw("Horizontal");
            // 入力に応じてBarを水平に動かす
            m_rb2d.velocity = h * Vector2.right * m_speed;
        }

        /// <summary>
        /// SpaceKeyが押されるまで最初のボールの射出を待つコルーチン
        /// </summary>
        IEnumerator BallPush()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            m_ball.transform.position = m_muzzle.transform.position;
            m_ball.gameObject.SetActive(true);
        }

        protected override void OnEnable()
        {
            StartCoroutine(BallPush());
        }

        protected override void OnDisable()
        {
            
        }
    }
}