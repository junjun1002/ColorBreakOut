using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

namespace ColorBreakOut
{
    /// <summary>
    /// オーディオの情報を保持しているScriptableObject
    /// </summary>
    [Serializable, CreateAssetMenu(fileName = "AudioDataList", menuName = "Data/AudioDataList")]
    public class AudioDataList : ScriptableObject
    {
        public Dictionary<string, AudioClip> audioClipDic = new Dictionary<string, AudioClip>();

        /// <summary>
        /// ランキングデータ
        /// </summary>
        [Serializable]
        public class AudioData
        {
            public string audioName;
            public AudioClip audioClip;
            public float pitch = 1;
            public float volume = 1;
        }


        [SerializeField] List<AudioData> audioList = new List<AudioData>();


        public List<AudioData> AudioList { get => audioList; }
    }
}