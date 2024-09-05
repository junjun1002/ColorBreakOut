using UnityEngine;
using TMPro;

namespace ColorBreakOut
{
    /// <summary>
    /// コンボのイベントを扱うクラス
    /// </summary>
    public class ComboEventHandler : EventReceiver<ComboEventHandler>
    {
        /// <summary>
        /// コンボ数を表示するText
        /// </summary>
        [SerializeField] TextMeshProUGUI m_comboText;

        /// <summary>
        /// コンボ数が変化したときに呼ばれる関数イベント
        /// OnEnableで登録
        /// </summary>
        /// <param name="combo"></param>
        public void OnComboChanged(int currentCombo)
        {
            m_comboText.text = "Combo : " + currentCombo;
        }

        /// <summary>
        /// イベントを解除
        /// </summary>
        protected override void OnDisable()
        {
            m_eventSystemInGame.ComboChangedEvent -= OnComboChanged;
        }

        /// <summary>
        /// イベントを登録
        /// </summary>
        protected override void OnEnable()
        {
            m_eventSystemInGame.ComboChangedEvent += OnComboChanged;
            m_comboText.text = "Combo : 0";
            m_comboText.gameObject.SetActive(true);
        }
    }
}