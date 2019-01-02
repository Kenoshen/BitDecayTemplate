using System;
public class Scenes
{
	public const string DontDestroyOnLoad = "DontDestroyOnLoad";
	public const string SampleScene = "SampleScene";
	public const string SceneOne = "SceneOne";
	public const string SceneTwo = "SceneTwo";
	public const string BitdecaySplash = "BitdecaySplash";
	public enum SceneEnum
	{
		SampleScene = 80,
		SceneOne = 16,
		SceneTwo = 40,
		BitdecaySplash = 144,
	}
	public static string GetSceneNameFromEnum(SceneEnum sceneEnum)
	{
		switch (sceneEnum)
		{
			case SceneEnum.SampleScene:
				return SampleScene;
			case SceneEnum.SceneOne:
				return SceneOne;
			case SceneEnum.SceneTwo:
				return SceneTwo;
			case SceneEnum.BitdecaySplash:
				return BitdecaySplash;
			default:
				throw new Exception("Unable to resolve scene name for: " + sceneEnum);
		}
	}
}
