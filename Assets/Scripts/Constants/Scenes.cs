using System;
public class Scenes
{
	public const string DontDestroyOnLoad = "DontDestroyOnLoad";
	public const string TitleScreen = "TitleScreen";
	public const string BitdecaySplash = "BitdecaySplash";
	public const string GameJamSplash = "GameJamSplash";
	public const string Credits = "Credits";
	public const string BitdecaySplash = "BitdecaySplash";
	public const string GameJamSplash = "GameJamSplash";
	public const string BitdecaySplash = "BitdecaySplash";
	public enum SceneEnum
	{
		TitleScreen = 98,
		BitdecaySplash = 144,
		GameJamSplash = 253,
		Credits = 206,
		BitdecaySplash = 144,
		GameJamSplash = 253,
		BitdecaySplash = 144,
	}
	public static string GetSceneNameFromEnum(SceneEnum sceneEnum)
	{
		switch (sceneEnum)
		{
			case SceneEnum.TitleScreen:
				return TitleScreen;
			case SceneEnum.BitdecaySplash:
				return BitdecaySplash;
			case SceneEnum.GameJamSplash:
				return GameJamSplash;
			case SceneEnum.Credits:
				return Credits;
			case SceneEnum.BitdecaySplash:
				return BitdecaySplash;
			case SceneEnum.GameJamSplash:
				return GameJamSplash;
			case SceneEnum.BitdecaySplash:
				return BitdecaySplash;
			default:
				throw new Exception("Unable to resolve scene name for: " + sceneEnum);
		}
	}
}
