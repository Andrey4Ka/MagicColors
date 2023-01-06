using Array2DEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Create level")]
public class Level : ScriptableObject
{
    public int Number { get; set; }
    public Level NextLevel { get; set; }
    public Sprite Gradient;
    public Array2DBool Interactables;
}