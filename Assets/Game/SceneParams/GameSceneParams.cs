using SceneParamsTransfering;
using UnityEngine;

public class GameSceneParams : BaseSceneParams
{
    public override SceneName SceneName => SceneName.GameScene;
    public Level Level { get; }

    public GameSceneParams() : base(null)
    {
        Level = Resources.LoadAll<Level>("Levels/")[0];
    }

    public GameSceneParams(Level level, Save save) : base(save)
    {
        Level = level;
    }
}
