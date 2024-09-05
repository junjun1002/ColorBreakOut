namespace ColorBreakOut
{
    /// <summary>
    /// ゲームのステート情報だけを所持しているクラス
    /// </summary>
    public class GameState : SingletonMonoBehavior<GameState>
    {
        #region GameState
        public StateMachine<GameManager> stateMachine;

        /// <summary>
        /// タイトルステート
        /// </summary>
        private IState<GameManager> titleState = new Title();
        public IState<GameManager> TitleState { get => titleState; }

        /// <summary>
        /// インゲームステート
        /// </summary>
        private IState<GameManager> inGameState = new InGame();
        public IState<GameManager> InGameState { get => inGameState; }

        /// <summary>
        /// リザルトステート
        /// </summary>
        private IState<GameManager> resultState = new Result();
        public IState<GameManager> ResultState { get => resultState; }

        #endregion

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
            stateMachine = new StateMachine<GameManager>(GameManager.Instance, titleState);
        }
    }
}