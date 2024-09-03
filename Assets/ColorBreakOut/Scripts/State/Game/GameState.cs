namespace ColorBreakOut
{
    /// <summary>
    /// �Q�[���̃X�e�[�g��񂾂����������Ă���N���X
    /// </summary>
    public class GameState : SingletonMonoBehavior<GameState>
    {
        #region GameState
        public StateMachine<GameManager> stateMachine;

        //private IState<GameManager> titleState = new Title();
        //public IState<GameManager> TitleState { get => titleState; }

        private IState<GameManager> inGameState = new InGame();
        public IState<GameManager> InGameState { get => inGameState; }

        private IState<GameManager> feverState = new Fever();
        public IState<GameManager> FeverState { get => feverState; }

        //private IState<GameManager> gameClearState = new GameClear();
        //public IState<GameManager> GameClearState { get => gameClearState; }

        //private IState<GameManager> gameOverState = new GameOver();
        //public IState<GameManager> GameOverState { get => gameOverState; }

        #endregion

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
            stateMachine = new StateMachine<GameManager>(GameManager.Instance, InGameState);
        }
    }
}