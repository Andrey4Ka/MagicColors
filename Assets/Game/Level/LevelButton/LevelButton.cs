using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    public event Action<Level> OnClick;

    [SerializeField] private Image _image;
    [SerializeField] private Text _levelNumber;

    public Level Level { get; private set; }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => OnClick?.Invoke(Level));
    }

    public void SetLevel(Level level)
    {
        Level = level;
        _levelNumber.text = level.Number.ToString();
    }

    public void RandomColor()
    {
        _image.color = UnityEngine.Random.ColorHSV(0, 1, 0.5f, 0.6f, .8f, .9f ,1, 1);
    }
}
