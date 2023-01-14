using SceneParamsTransfering;
using System.Collections;
using UnityEngine;

public class LevelsSceneParams : BaseSceneParams
{
    public override SceneName SceneName => SceneName.LevelsScene;

	public LevelsSceneParams() : base(null)
    {

	}

	public LevelsSceneParams(Save save) : base(save)
	{

	}
}