using TMPro;
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

        /// <summary>
        /// �����L���O���J��
        /// </summary>
        /// <param name="ranking"></param>
        public void OpenRanking(GameObject ranking)
        {
            ranking.SetActive(true);
        }

        /// <summary>
        /// �Q�[�����I������
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}