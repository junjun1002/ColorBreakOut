namespace ColorBreakOut
{
    /// <summary>
    /// インゲームのステート情報だけを所持しているクラス
    /// </summary>
    public class InGameState : SingletonMonoBehavior<InGameState>
    {
        #region InGameState
        public StateMachine<InGameManager> stateMachine;

        /// <summary>
        /// デフォルトステート
        /// </summary>
        private IState<InGameManager> defaultState = new Default();
        public IState<InGameManager> DefaultState { get => defaultState; }

        /// <summary>
        /// フィーバーステート
        /// </summary>

        private IState<InGameManager> feverState = new Fever();
        public IState<InGameManager> FeverState { get => feverState; }
        #endregion

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            stateMachine = new StateMachine<InGameManager>(InGameManager.Instance, defaultState);
        }
    }
}