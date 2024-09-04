using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

namespace ColorBreakOut
{
    public class ScoreRankingDataEditor
    {
        [MenuItem("Assets/Create/Data/ScoreRankingData")]
        public static void CreateAndInitializeScoreRankingData()
        {
            // ScriptableObjectのインスタンスを作成
            var scoreRankingData = ScriptableObject.CreateInstance<ColorBreakOut.ScoreRankingData>();

            // 初期値を設定
            scoreRankingData.Initialize();

            // アセットとして保存
            AssetDatabase.CreateAsset(scoreRankingData, "Assets/ColorBreakOut/ScriptableObjects/Score/ScoreRankingData.asset");
            AssetDatabase.SaveAssets();

            // 作成したアセットを選択
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = scoreRankingData;
        }
    }
}