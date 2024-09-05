using ColorBreakOut;
using UnityEngine;

/// <summary>
/// �f�[�^�̕ۑ��A�ǂݍ��݂��s���N���X
/// </summary>
public class SaveManager : SingletonMonoBehavior<SaveManager>
{
    /// <summary>
    /// ����������
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }


    /// <summary>
    /// �f�[�^�̕ۑ�
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
    /// �f�[�^�̓ǂݍ���
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