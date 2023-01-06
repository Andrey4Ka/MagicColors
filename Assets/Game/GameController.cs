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

    private GameSceneParams sceneParams;

    private void Awake()
    {
        _field.OnWin += Win;
        _nextButton.OnClick += GoNext;
        _menuButton.onClick.AddListener(() => GoMenu());
        _errorHint.OnDown += () => _field.ToggleErrorHint(true);
        _errorHint.OnUp += () => _field.ToggleErrorHint(false);
    }

    private void Start()
    {
        sceneParams = SceneParamsTransfer.GetParams<GameSceneParams>();
        StartCoroutine(_field.InitField(sceneParams.Level));
        _levelText.SetLevel(sceneParams.Level.Number);
    }

    private void Win()
    {
        _hintController.SetShow(true);
        _nextButton.SetActive(true);
    }

    private void NextClickHandler()
    {
        //YandexBridge.ShowAd();
    }

    private void GoNext()
    {
        if (sceneParams.Level.NextLevel == null)
        {
            GoMenu();
            return;
        }

        SceneParamsTransfer.LoadScene(new GameSceneParams(sceneParams.Level.NextLevel));
    }

    private void GoMenu()
    {
        SceneParamsTransfer.LoadScene(new LevelsSceneParams());
    }
}
