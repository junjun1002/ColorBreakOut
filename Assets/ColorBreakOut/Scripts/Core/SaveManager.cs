using ColorBreakOut;
using UnityEngine;

/// <summary>
/// データの保存、読み込みを行うクラス
/// </summary>
public class SaveManager : SingletonMonoBehavior<SaveManager>
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }


    /// <summary>
    /// データの保存
    /// </summary>
    /// <param name="scoreRankingData"></param>
    public void SaveScriptableObject(ScoreRankingData scoreRankingData)
    {
        string jsonData = JsonUtility.ToJson(scoreRankingData);
        PlayerPrefs.SetString("ScoreRankingData", jsonData);
        PlayerPrefs.Save();
        Debug.Log("ScriptableObject saved: " + jsonData);
    }

    /// <summary>
    /// データの読み込み
    /// </summary>
    /// <param name="scoreRankingData"></param>
    public void LoadScriptableObject(ScoreRankingData scoreRankingData)
    {
        if (PlayerPrefs.HasKey("ScoreRankingData"))
        {
            string jsonData = PlayerPrefs.GetString("ScoreRankingData");
            JsonUtility.FromJsonOverwrite(jsonData, scoreRankingData);
            Debug.Log("ScriptableObject loaded: " + jsonData);
        }
        else
        {
            Debug.LogWarning("No data found in PlayerPrefs");
        }
    }
}