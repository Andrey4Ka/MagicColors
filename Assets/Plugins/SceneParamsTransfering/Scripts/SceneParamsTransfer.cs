using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneParamsTransfering
{
    /// <summary>
    /// Класс для загрузки сцены с параметрами
    /// </summary>
    public static class SceneParamsTransfer
    {
        /// <summary>
        /// Загрузить сцену с передачей параметров
        /// </summary>
        /// <param name="sceneParams">Параметры сцены</param>
        public static void LoadScene(ISceneParams sceneParams)
        {
            PrepareTransfer(sceneParams);
            SceneManager.LoadScene(sceneParams.SceneName.ToString());
        }

        /// <summary>
        /// Получить переданные на сцену параметры
        /// </summary>
        public static T GetParams<T>() where T : class, ISceneParams, new()
        {
            T sceneParams = null;
            Object.FindObjectOfType<TransferDontDestroyHandler>()?.GetParams(out sceneParams);
            if (sceneParams == null)
            {
                Debug.LogWarning("Scene params was not found. The default parameters will be set.");
                sceneParams = new T();
            }

            return sceneParams;
        }

        private static void PrepareTransfer(ISceneParams sceneParams)
        {
            var transfer = new GameObject("SceneTransfer", typeof(TransferDontDestroyHandler)).GetComponent<TransferDontDestroyHandler>();
            transfer.Transfer(sceneParams);
        }
    }
}
