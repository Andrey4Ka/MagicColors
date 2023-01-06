using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LevelText : MonoBehaviour
{
    [SerializeField, TextArea] private string _postfix;

    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void SetLevel(int level)
    {
        _text.text = level + _postfix;
    }
}
