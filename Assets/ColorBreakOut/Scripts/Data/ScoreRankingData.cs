using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

namespace ColorBreakOut
{
    /// <summary>
    /// 各スコア情報を保持しているScriptableObject
    /// </summary>
    public class ScoreRankingData : ScriptableObject
    {
        /// <summary>
        /// ランキングデータ
        /// </summary>
        [Serializable]
        public class RankingData
        {
            public string userName;
            public int score;
        }

        [SerializeField] List<RankingData> rankingList = new List<RankingData>();

        public List<RankingData> RankingList { get => rankingList; }

        /// <summary>
        /// 初期値を設定するメソッド
        /// </summary>
        public void Initialize()
        {
            rankingList = new List<RankingData>
            {
                new RankingData { userName = "Player1", score = 1000 },
                new RankingData { userName = "Player2", score = 900 },
                new RankingData { userName = "Player3", score = 800 },
                new RankingData { userName = "Player4", score = 700 },
                new RankingData { userName = "Player5", score = 600 }
            };
        }
    }
}