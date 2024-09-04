namespace ColorBreakOut
{
    /// <summary>
    /// ゲームのステート情報だけを所持しているクラス
    /// </summary>
    public class GameState : SingletonMonoBehavior<GameState>
    {
        #region GameState
        public StateMachine<GameManager> stateMachine;

        private IState<GameManager> titleState = new Title();
        public IState<GameManager> TitleState { get => titleState; }

        private IState<GameManager> inGameState = new InGame();
        public IState<GameManager> InGameState { get => inGameState; }

        private IState<GameManager> resultState = new Result();
        public IState<GameManager> ResultState { get => resultState; }

        #endregion

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
            stateMachine = new StateMachine<GameManager>(GameManager.Instance, titleState);
        }
    }
}