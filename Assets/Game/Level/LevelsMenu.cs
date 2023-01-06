using SceneParamsTransfering;
using System.Collections;
using UnityEngine;

public class LevelsMenu : MonoBehaviour
{
    [SerializeField] private LevelButton _levelPrefab;

    private const string LevelsPath = "Levels/";

    private void Start()
    {
        SceneParamsTransfer.GetParams<LevelsSceneParams>();
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        var levels = Resources.LoadAll<Level>(LevelsPath);

        for (int i = 0; i < levels.Length; i++)
        {
            var level = levels[i];
            level.Number = i + 1;
            if (i != levels.Length - 1)
            {
                level.NextLevel = levels[i + 1];
            }

            var levelButton = Instantiate(_levelPrefab, transform);
            levelButton.SetLevel(level);
            levelButton.RandomColor();
            levelButton.OnClick += (level) => StartCoroutine(ClickLevel(level));
        }
    }

    private IEnumerator ClickLevel(Level level)
    {
        yield return null;
        SceneParamsTransfer.LoadScene(new GameSceneParams(level));
    }
}
