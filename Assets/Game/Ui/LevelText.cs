using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LevelText : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void SetLevel(int level)
    {
        _text.text = level.ToString();
    }
}
