namespace ColorBreakOut
{
    /// <summary>
    /// インゲームのステート情報だけを所持しているクラス
    /// </summary>
    public class InGameState : SingletonMonoBehavior<InGameState>
    {
        #region InGameState
        public StateMachine<InGameManager> stateMachine;

        //private IState<GameManager> titleState = new Title();
        //public IState<GameManager> TitleState { get => titleState; }

        private IState<InGameManager> defaultState = new Default();
        public IState<InGameManager> DefaultState { get => defaultState; }

        private IState<InGameManager> feverState = new Fever();
        public IState<InGameManager> FeverState { get => feverState; }

        //private IState<GameManager> gameClearState = new GameClear();
        //public IState<GameManager> GameClearState { get => gameClearState; }

        //private IState<GameManager> gameOverState = new GameOver();
        //public IState<GameManager> GameOverState { get => gameOverState; }

        #endregion

        protected override void Awake()
        {
            base.Awake();
            stateMachine = new StateMachine<InGameManager>(InGameManager.Instance, defaultState);
        }
    }
}