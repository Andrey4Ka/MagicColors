using SceneParamsTransfering;
using UnityEngine;

public class GameSceneParams : ISceneParams
{
    public SceneName SceneName => SceneName.GameScene;
    public Level Level { get; }

    public GameSceneParams()
    {
        Level = Resources.LoadAll<Level>("Levels/")[0];
    }

    public GameSceneParams(Level level)
    {
        Level = level;
    }
}
