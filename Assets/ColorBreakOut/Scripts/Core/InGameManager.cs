using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// インゲームの管理をするマネージャークラス
    /// </summary>
    public class InGameManager : SingletonMonoBehavior<InGameManager>
    {
        /// <summary>
        /// フィーバータイムのスカイボックス
        /// </summary>
        [SerializeField] public Material m_feverSkybox;
        /// <summary>
        /// デフォルトのスカイボックス
        /// </summary>
        [SerializeField] public Material m_defaultSkybox;

        /// <summary> InGame中のイベント </summary>
        [SerializeField, HideInInspector] public EventSystemInGame m_eventSystemInGame;
        [SerializeField, HideInInspector] public InGameState m_inGameState;
        public StateMachine<InGameManager> stateMachine;

        private GameManager m_gameManager;

        /// <summary>
        /// 初期化処理
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
            // Awake()だとインゲームステートを取得できないためStart()で取得
            stateMachine = m_inGameState.stateMachine;
        }

        /// <summary>
        /// フィーバータイムに移行
        /// </summary>
        public void ChangeFeverMode()
        {
            stateMachine.ChageMachine(m_inGameState.FeverState);
        }

        /// <summary>
        /// ゲーム終了時の処理
        /// </summary>
        public void OnGameEnd()
        {
            m_gameManager.ChangeScene(m_gameManager.m_gameState.ResultState, m_gameManager.m_result);
        }
    }
}