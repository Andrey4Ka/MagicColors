using SceneParamsTransfering;

public abstract class BaseSceneParams : ISceneParams
{
    public abstract SceneName SceneName { get; }
    public Save Save { get; }

    public BaseSceneParams(Save save)
    {
        Save = save;
    }
}
