using UnityEngine.SceneManagement;

namespace ColorBreakOut
{
    /// <summary>
    /// �V�[���̃t�F�[�h���s���N���X
    /// </summary>
    public class SceneLoader
    {
        /// <summary>
        /// �V�[�������[�h������֐�
        /// </summary>
        /// <param name="sceneName"></param>
        public void Load(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}