namespace ColorBreakOut
{
    /// <summary>
    /// �Q�[���̃X�e�[�g��񂾂����������Ă���N���X
    /// </summary>
    public class GameState : SingletonMonoBehavior<GameState>
    {
        #region GameState
        public StateMachine<GameManager> stateMachine;

        /// <summary>
        /// �^�C�g���X�e�[�g
        /// </summary>
        private IState<GameManager> titleState = new Title();
        public IState<GameManager> TitleState { get => titleState; }

        /// <summary>
        /// �C���Q�[���X�e�[�g
        /// </summary>
        private IState<GameManager> inGameState = new InGame();
        public IState<GameManager> InGameState { get => inGameState; }

        /// <summary>
        /// ���U���g�X�e�[�g
        /// </summary>
        private IState<GameManager> resultState = new Result();
        public IState<GameManager> ResultState { get => resultState; }

        #endregion

        /// <summary>
        /// ����������
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
            stateMachine = new StateMachine<GameManager>(GameManager.Instance, titleState);
        }
    }
}