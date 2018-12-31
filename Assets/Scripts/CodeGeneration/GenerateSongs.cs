using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GenerateSongs : MonoBehaviour
{
    private const string DontDestroyOnLoadScene = "DontDestroyOnLoad";
    
    [MenuItem("Tools/Generate Songs")]
    public static void CreateTags()
    {
        string outputPath = EditorUtility.SaveFilePanelInProject(
            title: "Save Location",
            defaultName: "Songs",
            extension: "cs",
            message: "Where do you want to save the song names?");
        
        
        string classDefinition = string.Empty;

        classDefinition += "public class Songs\n";

        classDefinition += "{\n";

        classDefinition += "\tpublic enum SongEnum\n";
        classDefinition += "\t{\n";
        
        List<string> SongNames = new List<string>();
        
        foreach (string sceneName in SongNames)
        {
            byte[] sceneAsByteArray = System.Text.Encoding.UTF8.GetBytes(sceneName.ToCharArray());
            byte sceneEnumByteValue = 0;
            foreach (byte b in sceneAsByteArray)
            {
                sceneEnumByteValue += b;
            }
            classDefinition += string.Format("\t\t{0} = {1},\n", sceneName, sceneEnumByteValue);
        }
        
        classDefinition += "\t}\n";
        classDefinition += "}\n";
        
        File.WriteAllText(outputPath, classDefinition);
    }
}