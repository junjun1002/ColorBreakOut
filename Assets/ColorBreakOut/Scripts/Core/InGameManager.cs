using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �Q�[���S�̂̊Ǘ�������}�l�[�W���[�N���X
    /// </summary>
    public class InGameManager : SingletonMonoBehavior<InGameManager>
    {
        /// <summary> InGame���̃C�x���g </summary>
        [SerializeField, HideInInspector] public EventSystemInGame m_eventSystemInGame;
        [SerializeField, HideInInspector] public InGameState m_inGameState;
        public StateMachine<InGameManager> stateMachine;

        private GameManager m_gameManager;

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
            stateMachine = m_inGameState.stateMachine;
        }

        /// <summary>
        /// �t�B�[�o�[�^�C���Ɉڍs
        /// </summary>
        public void ChangeFeverMode()
        {
            stateMachine.ChageMachine(m_inGameState.FeverState);
        }

        public void OnGameEnd()
        {
            m_gameManager.ChangeScene(m_gameManager.m_gameState.ResultState, m_gameManager.m_result);
        }
    }
}