using ColorBreakOut;
using UnityEngine;
public class SaveManager : SingletonMonoBehavior<SaveManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }


    public void SaveScriptableObject(ScoreRankingData scoreRankingData)
    {
        string jsonData = JsonUtility.ToJson(scoreRankingData);
        PlayerPrefs.SetString("ScoreRankingData", jsonData);
        PlayerPrefs.Save();
        Debug.Log("ScriptableObject saved: " + jsonData);
    }
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