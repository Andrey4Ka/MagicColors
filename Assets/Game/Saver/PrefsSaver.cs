using UnityEngine;

namespace Game
{
    public class PrefsSaver : MonoBehaviour
    {
        private const string LevelKey = "CompleteLevel";
        private const string SoundKey = "SoundActive";
        private const string MusicKey = "MusicActive";

        public Save GetSave()
        {
            return new Save(
                    YandexPrefs.GetInt(LevelKey, 0)
                );
        }

        public void Save(Save save)
        {
            YandexPrefs.SetInt(LevelKey, save.CompletedLevel);
        }

        public void Clear()
        {
        }
    }
}