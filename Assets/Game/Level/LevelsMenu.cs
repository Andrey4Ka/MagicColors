using SceneParamsTransfering;
using System.Collections;
using UnityEngine;
using System.Linq;
using Game;

public class LevelsMenu : MonoBehaviour
{
    [SerializeField] private LevelButton _levelPrefab;
    [SerializeField] private MainSaver _mainSaver;

    private LevelsSceneParams _sceneParams;
    private Save _save;

    private const string LevelsPath = "Levels/";

    private void Start()
    {
        _sceneParams = SceneParamsTransfer.GetParams<LevelsSceneParams>();
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        var levels = Resources.LoadAll<Level>(LevelsPath);
        levels = levels.OrderBy(l => l.Number).ToArray();
        _save = _sceneParams.Save != null ? _sceneParams.Save : _mainSaver.GetSave();
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
            levelButton.SetOpened(level.Number <= _save.CompletedLevel + 1);
            levelButton.OnClick += (level) => StartCoroutine(ClickLevel(level));
        }
    }

    private IEnumerator ClickLevel(Level level)
    {
        yield return null;
        SceneParamsTransfer.LoadScene(new GameSceneParams(level, _save));
    }
}
