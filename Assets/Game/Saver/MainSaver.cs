using UnityEngine;

namespace Game
{
    public class MainSaver : MonoBehaviour
    {
        [SerializeField] private PrefsSaver _playerPrefsSaver;

        public Save GetSave()
        {
            return _playerPrefsSaver.GetSave();
        }

        public void Save(Save save)
        {
            _playerPrefsSaver.Save(save);
        }

        [ContextMenu("ClearSave")]
        public void Clear()
        {
            _playerPrefsSaver.Clear();
        }
    }
}
