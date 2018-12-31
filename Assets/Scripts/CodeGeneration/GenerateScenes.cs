using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class GenerateScenes : MonoBehaviour
{
    private const string DontDestroyOnLoadScene = "DontDestroyOnLoad";
    
    [MenuItem("Tools/Generate Scenes")]
    public static void CreateTags()
    {
        string outputPath = EditorUtility.SaveFilePanelInProject(
            title: "Save Location",
            defaultName: "Scenes",
            extension: "cs",
            message: "Where do you want to save the scene names?");
        
        
        string classDefinition = string.Empty;

        classDefinition += "using System;\n";
        classDefinition += "public class Scenes\n";

        classDefinition += "{\n";

        List<string> sceneNamesList = new List<string>();
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;   
        for( int i = 0; i < sceneCount; i++ )
        {            
            sceneNamesList.Add(Path.GetFileNameWithoutExtension( UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( i )));
        }

        classDefinition += string.Format("\tpublic const string {0} = \"{0}\";\n", DontDestroyOnLoadScene);
        foreach (string sceneName in sceneNamesList)
        {
            classDefinition += string.Format("\tpublic const string {0} = \"{0}\";\n", sceneName);
        }

        classDefinition += "\tpublic enum SceneEnum\n";
        classDefinition += "\t{\n";
        
        foreach (string sceneName in sceneNamesList)
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
        
        classDefinition += "\tpublic static string GetSceneNameFromEnum(SceneEnum sceneEnum)\n";
        classDefinition += "\t{\n";
        classDefinition += "\t\tswitch (sceneEnum)\n";
        classDefinition += "\t\t{\n";
        
        foreach (string sceneName in sceneNamesList)
        {

            classDefinition += string.Format("\t\t\tcase SceneEnum.{0}:\n", sceneName);
            classDefinition += string.Format("\t\t\t\treturn {0};\n", sceneName);
        }

        classDefinition += "\t\t\tdefault:\n";
        classDefinition += "\t\t\t\tthrow new Exception(\"Unable to resolve scene name for: \" + sceneEnum);\n";
        
        classDefinition += "\t\t}\n";
        classDefinition += "\t}\n";
        classDefinition += "}\n";
        
        File.WriteAllText(outputPath, classDefinition);
    }
}