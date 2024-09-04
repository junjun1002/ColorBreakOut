using System.Collections.Generic;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// ブロックを生成するクラス
    /// </summary>
    public class BlockGenerater : MonoBehaviour
    {
        #region GenerateBlock
        /// <summary>並べるプレハブを指定する。複数指定できる</summary>
        [SerializeField] GameObject[] m_blockArr;
        /// <summary>Blockを生成する位置</summary>
        [SerializeField] GameObject m_generatePos;
        /// <summary>横にいくつ並べるか</summary>
        [SerializeField] int m_columns = 7;
        /// <summary>縦にいくつ並べるか</summary>
        [SerializeField] int m_rows = 6;
        /// <summary>生成されたブロックを格納しておくための配列</summary>
        [SerializeField, HideInInspector] List<GameObject> m_blockList;
        #endregion

        private EventSystemInGame m_eventSystemInGame;
        private InGameManager m_inGameManager;

        private void Awake()
        {
            m_eventSystemInGame = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystemInGame>();
            m_inGameManager = InGameManager.Instance;
        }

        /// <summary>
        /// ブロックを生成する関数
        /// </summary>
        public void GenerateBlock()
        {
            if (m_blockList.Count != 0)
            {
                for (int i = 0; i < m_blockList.Count; i++)
                {
                    m_blockList[i].gameObject.SetActive(true);
                    m_eventSystemInGame.CurrentBlock++;
                }
                return;
            }
            Vector2 pos = m_generatePos.transform.position;   // pos は「ブロックを配置する位置」
            float blockHeight = 0f, blockWidth = 0f;

            // ブロックを並べる
            for (int j = 0; j < m_rows; j++)
            {
                // 横に並べる
                for (int i = 0; i < m_columns; i++)
                {
                    int prefabIndex = j % m_blockArr.Length;
                    GameObject block = Instantiate(m_blockArr[prefabIndex], pos, m_generatePos.transform.rotation);  // プレハブからオブジェクトを生成する
                    block.transform.position = pos;    // オブジェクトの位置を設定する
                    block.transform.SetParent(this.transform); // 生成したブロックを自分自身の子オブジェクトに設定する
                    blockWidth = block.GetComponent<SpriteRenderer>().bounds.size.x;   // いま生成したオブジェクトの高さと幅を取得する
                    blockHeight = block.GetComponent<SpriteRenderer>().bounds.size.y;
                    int a = (i % 2 == 0) ? 1 : -1;
                    pos = pos + Vector2.right * (i + 1) * a * blockWidth; // 列を左右にずらす
                    m_blockList.Add(block);
                    m_eventSystemInGame.CurrentBlock++;
                }
                // 行を下にずらす
                pos = new Vector2(transform.position.x, pos.y - blockHeight);
            }
        }

        private void OnEnable()
        {
            GenerateBlock();
        }
    }
}