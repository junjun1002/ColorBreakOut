using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �Q�[���S�̂̊Ǘ�������}�l�[�W���[�N���X
    /// </summary>
    public class GameManager : SingletonMonoBehavior<GameManager>
    {
        /// <summary> InGame���̃C�x���g </summary>
        [SerializeField] public EventSystemInGame m_eventSystemInGame;

        public GameState gameState;
        public StateMachine<GameManager> stateMachine;

        protected override void Awake()
        {
            base.Awake();
            m_eventSystemInGame = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystemInGame>();
            gameState = GameState.Instance;
        }

        private void Start()
        {
            stateMachine = gameState.stateMachine;
        }

        /// <summary>
        /// �t�B�[�o�[�^�C���Ɉڍs
        /// </summary>
        public void ChangeFeverMode()
        {
            stateMachine.ChageMachine(gameState.FeverState);
        }

        ///// <summary>
        ///// �^�C�g���V�[���ɑJ��
        ///// </summary>
        //public void ChangeTitleScene()
        //{
        //    stateMachine.ChageMachine(gameState.TitleState);
        //    SceneLoader.Instance.Load(m_title);
        //}

        ///// <summary>
        ///// �Q�[���V�[���ɑJ��
        ///// </summary>
        //public void ChangeGameScene()
        //{
        //    stateMachine.ChageMachine(gameState.InGameState);
        //    SceneLoader.Instance.Load(m_battle);
        //}

        ///// <summary>
        ///// �Q�[���N���A
        ///// </summary>
        //public void GameClear()
        //{
        //    stateMachine.ChageMachine(gameState.GameClearState);
        //    SaveAndLoad.Instance.SaveTimeData(m_minute, m_seconds);
        //    SceneLoader.Instance.Load(m_gameClear);
        //}

        //public void GameOver()
        //{
        //    stateMachine.ChageMachine(gameState.GameOverState);
        //    SceneLoader.Instance.Load(m_gameOver);
        //}
    }
}