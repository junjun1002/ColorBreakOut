using UnityEngine.SceneManagement;

namespace ColorBreakOut
{
    /// <summary>
    /// シーンのフェードを行うクラス
    /// </summary>
    public class SceneLoader
    {
        /// <summary>
        /// シーンをロードさせる関数
        /// </summary>
        /// <param name="sceneName"></param>
        public void Load(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}