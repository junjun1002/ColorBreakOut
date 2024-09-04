using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// ゲーム全体の管理をするマネージャークラス
    /// </summary>
    public class GameManager : SingletonMonoBehavior<GameManager>
    {
        #region Scene Name
        /// <summary>タイトルシーンの名前</summary>
        [SerializeField] public string m_title = "Title";
        /// <summary>バトルシーン名前</summary>
        [SerializeField] public string m_inGame = "InGame";
        /// <summary>リザルトシーンの名前</summary>
        [SerializeField] public string m_result = "Result";
        #endregion

        [SerializeField, HideInInspector]public GameState m_gameState;
        public StateMachine<GameManager> stateMachine;

        private SceneLoader m_sceneLoader;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
            m_sceneLoader = new SceneLoader();
            m_gameState = GameState.Instance;
        }

        private void Start()
        {
            stateMachine = m_gameState.stateMachine;
        }

        /// <summary>
        /// シーンの切り替え
        /// </summary>
        /// <param name="state"></param>
        /// <param name="sceneName"></param>
        public void ChangeScene(IState<GameManager> state, string sceneName)
        {
            stateMachine.ChageMachine(state);
            m_sceneLoader.Load(sceneName);
        }
    }
}