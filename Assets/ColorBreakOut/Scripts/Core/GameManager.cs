using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �Q�[���S�̂̊Ǘ�������}�l�[�W���[�N���X
    /// </summary>
    public class GameManager : SingletonMonoBehavior<GameManager>
    {
        #region Scene Name
        /// <summary>�^�C�g���V�[���̖��O</summary>
        [SerializeField] public string m_title = "Title";
        /// <summary>�o�g���V�[�����O</summary>
        [SerializeField] public string m_inGame = "InGame";
        /// <summary>���U���g�V�[���̖��O</summary>
        [SerializeField] public string m_result = "Result";
        #endregion

        /// <summary>
        /// �Q�[���I�����̃X�R�A
        /// </summary>
        [SerializeField, HideInInspector] public int m_resultScore = 0;
        /// <summary>
        /// �����L���O�ɓ��邩�ǂ���
        /// </summary>
        [SerializeField, HideInInspector] public bool m_isRanking = false;

        /// <summary>
        /// �X�R�A�����L���O�f�[�^
        /// </summary>
        [SerializeField] public ScoreRankingData m_scoreRankingData;

        [SerializeField, HideInInspector] public GameState m_gameState;
        public StateMachine<GameManager> stateMachine;

        private SceneLoader m_sceneLoader;

        /// <summary>
        /// ����������
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
            m_sceneLoader = new SceneLoader();
            m_gameState = GameState.Instance;
        }

        private void Start()
        {
            // Awake()���ƃQ�[���X�e�[�g���擾�ł��Ȃ�����Start()�Ŏ擾
            stateMachine = m_gameState.stateMachine;
        }

        /// <summary>
        /// �V�[���̐؂�ւ�
        /// </summary>
        /// <param name="state"></param>
        /// <param name="sceneName"></param>
        public void ChangeScene(IState<GameManager> state, string sceneName)
        {
            stateMachine.ChageMachine(state);
            m_sceneLoader.Load(sceneName);
        }

        /// <summary>
        /// �����L���O�̍X�V
        /// </summary>
        /// <param name="userName"></param>
        public void RankingUpdate(string userName)
        {
            m_scoreRankingData.RankingList[4].userName = userName;
            m_scoreRankingData.RankingList[4].score = m_resultScore;
        }

        /// <summary>
        /// �A�v���P�[�V�������I������ۂ̏���
        /// </summary>
        private void OnApplicationQuit()
        {
            SaveManager.Instance.SaveScriptableObject(m_scoreRankingData);
        }
    }
}