using System;
public class Scenes
{
	public const string DontDestroyOnLoad = "DontDestroyOnLoad";
	public const string SampleScene = "SampleScene";
	public enum SceneEnum
	{
		SampleScene = 80,
	}
	public static string GetSceneNameFromEnum(SceneEnum sceneEnum)
	{
		switch (sceneEnum)
		{
			case SceneEnum.SampleScene:
				return SampleScene;
			default:
				throw new Exception("Unable to resolve scene name for: " + sceneEnum);
		}
	}
}
