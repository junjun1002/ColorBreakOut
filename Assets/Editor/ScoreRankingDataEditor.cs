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
            // ScriptableObject�̃C���X�^���X���쐬
            var scoreRankingData = ScriptableObject.CreateInstance<ColorBreakOut.ScoreRankingData>();

            // �����l��ݒ�
            scoreRankingData.Initialize();

            // �A�Z�b�g�Ƃ��ĕۑ�
            AssetDatabase.CreateAsset(scoreRankingData, "Assets/ColorBreakOut/ScriptableObjects/Score/ScoreRankingData.asset");
            AssetDatabase.SaveAssets();

            // �쐬�����A�Z�b�g��I��
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = scoreRankingData;
        }
    }
}