using UnityEngine;

namespace SceneParamsTransfering
{
    /// <summary>
    /// Вспомогательный класс для передачи данных.
    /// При загрузке сцены в DontDestroyOnLoad создается объект с таким типом, и уничтожается после передачи данных.
    /// </summary>
    public class TransferDontDestroyHandler : MonoBehaviour
    {
        private ISceneParams SceneParams { get; set; }

        /// <summary>
        /// Получить параметры и уничтожить объект.
        /// </summary>
        public void GetParams<T>(out T sceneParams) where T : ISceneParams
        {
            sceneParams = (T)SceneParams;
            Destroy(gameObject);
        }

        /// <summary>
        /// Поготовить объект для передачи параметров.
        /// </summary>
        /// <param name="sceneParams"></param>
        public void Transfer(ISceneParams sceneParams)
        {
            SceneParams = sceneParams;
            DontDestroyOnLoad(gameObject);
        }
    }
}
