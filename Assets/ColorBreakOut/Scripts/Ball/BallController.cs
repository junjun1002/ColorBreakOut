using System.Collections.Generic;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// ボールを制御するクラス
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallController : EventReceiver<BallController>
    {
        //ボールの初期設定
        #region InitSetting
        /// <summary>ボールが最初に動く方向</summary>
        [SerializeField] Vector2 m_powerDirection = Vector2.up + Vector2.right;
        /// <summary>ボールを最初に動かす力の大きさ</summary>
        [SerializeField] float m_powerScale = 5f;
        /// <summary>ボールの色のリスト</summary>
        [SerializeField] List<Color> m_colorList = new List<Color>();
        /// <summary>フィーバーモードのボールのエフェクト</summary>
        [SerializeField] GameObject m_feverEffect;
        #endregion

        private Rigidbody2D m_rb2d;
        private SpriteRenderer m_spriteRenderer;

        // 現在の色のインデックス
        private int m_currentColorIndex = 0;

        //ボールに補正を書ける変数群
        #region BallCorrection 
        /// <summary>ボールの最高速度</summary>
        [SerializeField] float m_maxSpeed = 5f;
        /// <summary>ボールの最低速度</summary>
        [SerializeField] float m_minSpeed = 1f;
        /// <summary>これ以上ボールの進行方向が水平になったら補正を入れるというリミット</summary>
        [SerializeField] float m_horizontalLimit = 0.05f;
        /// <summary>ボールに補正を入れる時のベクトル</summary>
        [SerializeField] Vector2 m_adjustVector = Vector3.down * 3f;
        #endregion

        /// <summary>
        /// アクティブがtrue時にボールに力を加える関数
        /// </summary>
        private void Push()
        {
            m_rb2d.AddForce(m_powerDirection.normalized * m_powerScale, ForceMode2D.Impulse);
        }


        // イベント関係
        #region Event
        /// <summary>
        /// 衝突判定のイベント
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //SoundManager.Instance.PlaySE(SoundManager.Instance.m_ballSe);

            // 衝突相手がバーならバーのどの位置に当たったか加える力を変える
            if (collision.gameObject.TryGetComponent<BarController>(out var barController))
            {
                float hitFactor = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
                Vector2 direction = new Vector2(hitFactor, 1).normalized;
                m_rb2d.velocity = direction * m_rb2d.velocity.magnitude;
            }

            // 衝突相手がIEventCollisionを持っていたらその関数を呼ぶ
            if (collision.gameObject.TryGetComponent<IEventCollision>(out var eventCollision)) 
            {
                eventCollision.CollisionEvent(m_eventSystemInGame);
            }
            else
            {
                if (m_gameManager.stateMachine.CurrentState == m_gameState.FeverState) return;

                // ボールの色を変える
                for (int i = 0; i < m_colorList.Count; i++)
                {
                    if (m_currentColorIndex == m_colorList.Count - 1)
                    {
                        m_currentColorIndex = 0;
                        break;
                    }
                    else if (m_currentColorIndex < i)
                    {
                        m_currentColorIndex = i;
                        break;
                    }
                }
                m_spriteRenderer.color = m_colorList[m_currentColorIndex];
                m_eventSystemInGame.m_currentBallColor = m_colorList[m_currentColorIndex];
            }
        }

        private void ActiveFeverEfecftEvent()
        {
            m_feverEffect.SetActive(true);
            // 現在の色のインデックスを更新
            m_currentColorIndex = (m_currentColorIndex + 1) % m_colorList.Count;

            // 新しい色を設定
            m_spriteRenderer.color = m_colorList[m_currentColorIndex];
        }

        private void DeactiveFeverEfecftEvent()
        {
            m_feverEffect.SetActive(false);
        }

        /// <summary>
        /// Objectがアクティブになった時の処理
        /// ゲーム開始時とアイテムを取得したら基本的に呼ばれる
        /// </summary>
        protected override void OnEnable()
        {
            m_rb2d = GetComponent<Rigidbody2D>();
            m_spriteRenderer = GetComponent<SpriteRenderer>();
            m_spriteRenderer.color = m_colorList[m_currentColorIndex];
            m_eventSystemInGame.FeverStartEvent += ActiveFeverEfecftEvent;
            m_eventSystemInGame.FeverEndEvent += DeactiveFeverEfecftEvent;
            Push();
        }

        /// <summary>
        /// ActiveがFalseになったらListの最後に追加して再利用する
        /// </summary>
        protected override void OnDisable()
        {
            m_rb2d.velocity = Vector2.zero;
        }
        #endregion

        // 詰み防止の関数
        #region CheckmatePrevention
        /// <summary>
        /// 水平方向の詰み防止とスピード補正
        /// </summary>
        /// <param name="collision"></param>
        void OnCollisionExit2D(Collision2D collision)
        {
            Vector2 v = m_rb2d.velocity.normalized;
            // もし水平にぶつかっていたら、下向きに力を加える
            if (Mathf.Abs(v.y) < m_horizontalLimit)
            {
                m_rb2d.AddForce(m_adjustVector, ForceMode2D.Impulse);
            }

            AdjustSpeed();
        }

        /// <summary>
        /// ボールの速度を調整する
        /// スピードが早くなりすぎて壁抜けすることを防止するため
        /// </summary>
        void AdjustSpeed()
        {
            Vector2 v = m_rb2d.velocity;

            // もしボールのスピードが最低速度より遅いのなら
            if (v.magnitude < m_minSpeed)
            {
                m_rb2d.velocity = m_rb2d.velocity.normalized * m_minSpeed;
            }
            // もしボールのスピードが最高速度より早いのなら
            else if (v.magnitude > m_maxSpeed)
            {
                m_rb2d.velocity = m_rb2d.velocity.normalized * m_maxSpeed;
            }
        }

        /// <summary>
        /// バーのどの位置に当たったのかを計算する。
        /// 右端に当たったら 1、中央に当たったら 0、左端に当たったら -1 を返す
        /// ボールが垂直方向に動いた時の詰み防止とPlayerの技術でブロックを狙えるように
        /// </summary>
        /// <param name="ballPosition"></param>
        /// <param name="barPosition"></param>
        /// <param name="barWidth"></param>
        /// <returns></returns>
        float HitFactor(Vector2 ballPosition, Vector2 barPosition, float barWidth)
        {
            float hitFactor = (ballPosition.x - barPosition.x) / barWidth;
            return hitFactor;
        }
        #endregion
    }
}