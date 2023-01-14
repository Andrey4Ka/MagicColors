using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TitleColor : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Start()
    {
        _text.color = Random.ColorHSV(0f, 1f, 0.7f, 0.9f, 0.7f, 0.9f, 1f, 1f);
    }
}
