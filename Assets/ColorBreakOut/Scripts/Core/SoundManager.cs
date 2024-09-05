using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �Q�[���̉����Ǘ�����N���X
    /// </summary>
    public class SoundManager : SingletonMonoBehavior<SoundManager>
    {
        /// <summary>
        /// BGM���Đ����邽�߂�AudioSource
        /// </summary>
        [SerializeField] AudioSource m_bgmPlayer;
        /// <summary>
        /// SE���Đ����邽�߂�AudioSource
        /// </summary>
        [SerializeField] AudioSource m_sePlayer;

        /// <summary>
        /// BGM�̃��X�g
        /// </summary>
        [SerializeField] AudioDataList m_bgmDataList;
        /// <summary>
        /// SE�̃��X�g
        /// </summary>
        [SerializeField] AudioDataList m_seDataList;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this.gameObject);
        }

        /// <summary>
        /// BGM���Đ�����
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
        /// BGM���~����
        /// </summary>
        public void StopBGM()
        {
            m_bgmPlayer.Stop();
        }

        /// <summary>
        /// SE���Đ�����
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