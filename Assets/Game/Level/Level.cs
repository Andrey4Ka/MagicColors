using Array2DEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Create level")]
public class Level : ScriptableObject
{
    public Level NextLevel { get; set; }
    public int Number;
    public Sprite Gradient;
    public Array2DBool Interactables;
}