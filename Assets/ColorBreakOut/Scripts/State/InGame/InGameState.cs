namespace ColorBreakOut
{
    /// <summary>
    /// �C���Q�[���̃X�e�[�g��񂾂����������Ă���N���X
    /// </summary>
    public class InGameState : SingletonMonoBehavior<InGameState>
    {
        #region InGameState
        public StateMachine<InGameManager> stateMachine;

        /// <summary>
        /// �f�t�H���g�X�e�[�g
        /// </summary>
        private IState<InGameManager> defaultState = new Default();
        public IState<InGameManager> DefaultState { get => defaultState; }

        /// <summary>
        /// �t�B�[�o�[�X�e�[�g
        /// </summary>

        private IState<InGameManager> feverState = new Fever();
        public IState<InGameManager> FeverState { get => feverState; }
        #endregion

        /// <summary>
        /// ����������
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            stateMachine = new StateMachine<InGameManager>(InGameManager.Instance, defaultState);
        }
    }
}