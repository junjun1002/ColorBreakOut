using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using ColorBreakOut;
using TMPro;

namespace ColorBreakOut
{
    /// <summary>
    /// �R���{�̃C�x���g�������N���X
    /// </summary>
    public class ComboEventHandler : EventReceiver<ComboEventHandler>
    {
        [SerializeField] TextMeshProUGUI m_comboText;

        /// <summary>
        /// Block����ꂽ���ɌĂ΂��C�x���g
        /// OnEnable�œo�^
        /// </summary>
        /// <param name="combo"></param>
        public void OnComboChanged(int currentCombo)
        {
            m_comboText.text = "Combo : " + currentCombo;
        }

        /// <summary>
        /// �C�x���g������
        /// </summary>
        protected override void OnDisable()
        {
            m_eventSystemInGame.ComboChangedEvent -= OnComboChanged;
        }

        /// <summary>
        /// �C�x���g��o�^
        /// </summary>
        protected override void OnEnable()
        {
            m_eventSystemInGame.ComboChangedEvent += OnComboChanged;
            m_comboText.text = "Combo : 0";
            m_comboText.gameObject.SetActive(true);
        }
    }
}