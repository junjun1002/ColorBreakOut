using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �C���Q�[���̊Ǘ�������}�l�[�W���[�N���X
    /// </summary>
    public class InGameManager : SingletonMonoBehavior<InGameManager>
    {
        /// <summary>
        /// �t�B�[�o�[�^�C���̃X�J�C�{�b�N�X
        /// </summary>
        [SerializeField] public Material m_feverSkybox;
        /// <summary>
        /// �f�t�H���g�̃X�J�C�{�b�N�X
        /// </summary>
        [SerializeField] public Material m_defaultSkybox;

        /// <summary> InGame���̃C�x���g </summary>
        [SerializeField, HideInInspector] public EventSystemInGame m_eventSystemInGame;
        [SerializeField, HideInInspector] public InGameState m_inGameState;
        public StateMachine<InGameManager> stateMachine;

        private GameManager m_gameManager;

        /// <summary>
        /// ����������
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            m_gameManager = GameManager.Instance;
            m_eventSystemInGame = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystemInGame>();
            m_inGameState = InGameState.Instance;

            m_eventSystemInGame.GameEndEvent += OnGameEnd;
        }

        private void Start()
        {
            // Awake()���ƃC���Q�[���X�e�[�g���擾�ł��Ȃ�����Start()�Ŏ擾
            stateMachine = m_inGameState.stateMachine;
        }

        /// <summary>
        /// �t�B�[�o�[�^�C���Ɉڍs
        /// </summary>
        public void ChangeFeverMode()
        {
            stateMachine.ChageMachine(m_inGameState.FeverState);
        }

        /// <summary>
        /// �Q�[���I�����̏���
        /// </summary>
        public void OnGameEnd()
        {
            m_gameManager.ChangeScene(m_gameManager.m_gameState.ResultState, m_gameManager.m_result);
        }
    }
}