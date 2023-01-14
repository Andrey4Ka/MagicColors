using Game;
using SceneParamsTransfering;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Field _field;
    [SerializeField] private NextButton _nextButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private HintController _hintController;
    [SerializeField] private HintButton _errorHint;
    [SerializeField] private LevelText _levelText;
    [SerializeField] private MainSaver _mainSaver;
    [SerializeField] private SoundController _soundController;

    private GameSceneParams _sceneParams;
    private YandexBridge _yandexBridge;

    private void Awake()
    {
        _yandexBridge = YandexBridge.Create();
        _field.OnWin += Win;
        _nextButton.OnClick += NextClickHandler;
        _menuButton.onClick.AddListener(() => GoMenu());
        _errorHint.OnDown += () => _field.ToggleErrorHint(true);
        _errorHint.OnUp += () => _field.ToggleErrorHint(false);
        _yandexBridge.OnAdClosed += GoNext;
    }

    private void Start()
    {
        _sceneParams = SceneParamsTransfer.GetParams<GameSceneParams>();
        StartCoroutine(_field.InitField(_sceneParams.Level));
        _levelText.SetLevel(_sceneParams.Level.Number);
    }

    private void Win()
    {
        _sceneParams.Save.CompletedLevel = Mathf.Max(_sceneParams.Save.CompletedLevel, _sceneParams.Level.Number);
        _hintController.SetShow(true);
        _nextButton.SetActive(true);
        _mainSaver.Save(_sceneParams.Save);
    }

    private void NextClickHandler()
    {
        _soundController.HardMute();
        _yandexBridge.SendShowAd();
    }

    private void GoNext()
    {
        _soundController.HardUnmute();
        if (_sceneParams.Level.NextLevel == null)
        {
            GoMenu();
            return;
        }

        SceneParamsTransfer.LoadScene(new GameSceneParams(_sceneParams.Level.NextLevel, _sceneParams.Save));
    }

    private void GoMenu()
    {
        SceneParamsTransfer.LoadScene(new LevelsSceneParams(_sceneParams.Save));
    }
}
