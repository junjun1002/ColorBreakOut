using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// ゲームの音を管理するクラス
    /// </summary>
    public class SoundManager : SingletonMonoBehavior<SoundManager>
    {
        /// <summary>
        /// BGMを再生するためのAudioSource
        /// </summary>
        [SerializeField] AudioSource m_bgmPlayer;
        /// <summary>
        /// SEを再生するためのAudioSource
        /// </summary>
        [SerializeField] AudioSource m_sePlayer;

        /// <summary>
        /// BGMのリスト
        /// </summary>
        [SerializeField] AudioDataList m_bgmDataList;
        /// <summary>
        /// SEのリスト
        /// </summary>
        [SerializeField] AudioDataList m_seDataList;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this.gameObject);
        }

        /// <summary>
        /// BGMを再生する
        /// </summary>
        /// <param name="bgmName"></param>
        public void PlayBGM(string bgmName)
        {
            foreach (var audioData in m_bgmDataList.AudioList)
            {
                if (audioData.audioName == bgmName)
                {
                    m_bgmPlayer.clip = audioData.audioClip;
                    m_bgmPlayer.pitch = audioData.pitch;
                    m_bgmPlayer.volume = audioData.volume;
                }
            }

            m_bgmPlayer.Play();
        }

        /// <summary>
        /// BGMを停止する
        /// </summary>
        public void StopBGM()
        {
            m_bgmPlayer.Stop();
        }

        /// <summary>
        /// SEを再生する
        /// </summary>
        /// <param name="seName"></param>
        public void PlaySE(string seName)
        {
            foreach (var audioData in m_seDataList.AudioList)
            {
                if (audioData.audioName == seName)
                {
                    m_sePlayer.pitch = audioData.pitch;
                    m_sePlayer.volume = audioData.volume;
                    m_sePlayer.PlayOneShot(audioData.audioClip);
                }
            }
        }
    }
}