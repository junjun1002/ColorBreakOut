using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorBreakOut
{
    /// <summary>
    /// �^�C�g���V�[���̋@�\��S������N���X
    /// </summary>
    public class TitleSceneModel
    {
        /// <summary>
        /// �V�[���̐؂�ւ�
        /// </summary>
        /// <param name="nextScene"></param>
        public void ChangeScene(IState<GameManager> state, string sceneName)
        {
            GameManager.Instance.ChangeScene(state, sceneName);
        }
    }
}