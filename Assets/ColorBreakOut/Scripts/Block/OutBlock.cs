using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// ���̃R���|�[�l���g�ɓ��������������N���X
    /// </summary>
    public class OutBlock : MonoBehaviour
    {
        /// <summary>
        /// �{�[��������������A�N�e�B�u��False�ɂ���
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
        }
    }
}