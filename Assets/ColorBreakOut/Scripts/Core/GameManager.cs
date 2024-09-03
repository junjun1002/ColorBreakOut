using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// ゲーム全体の管理をするマネージャークラス
    /// </summary>
    public class GameManager : SingletonMonoBehavior<GameManager>
    {
        /// <summary> InGame中のイベント </summary>
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
        /// フィーバータイムに移行
        /// </summary>
        public void ChangeFeverMode()
        {
            stateMachine.ChageMachine(gameState.FeverState);
        }

        ///// <summary>
        ///// タイトルシーンに遷移
        ///// </summary>
        //public void ChangeTitleScene()
        //{
        //    stateMachine.ChageMachine(gameState.TitleState);
        //    SceneLoader.Instance.Load(m_title);
        //}

        ///// <summary>
        ///// ゲームシーンに遷移
        ///// </summary>
        //public void ChangeGameScene()
        //{
        //    stateMachine.ChageMachine(gameState.InGameState);
        //    SceneLoader.Instance.Load(m_battle);
        //}

        ///// <summary>
        ///// ゲームクリア
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