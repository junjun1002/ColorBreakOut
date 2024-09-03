using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ColorBreakOut
{
    /// <summary>
    /// BlockのデータのScriptableObject
    /// </summary>
    [Serializable, CreateAssetMenu(fileName = "BlockData", menuName = "Data/BlockData")]
    public class BlockData : ScriptableObject
    {
        [SerializeField, Header("ブロックの色")] Color color;
        [SerializeField, Header("壊れた時の追加スコア")] int score;
        [SerializeField, Header("ボールが当たったら壊れる回数")] int life;

        /// <summary>ブロックの色</summary>
        public Color Color { get => color; }
        /// <summary>壊れた時の追加スコア</summary>
        public int Score { get => score; }
        /// <summary>ボールが当たったら壊れる回数</summary>
        public int Life { get => life; }
    }
}