using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class GenerateSFX : MonoBehaviour
{
    [MenuItem("Tools/Generate SFX")]
    public static void CreateSFX()
    {
        string configPath = EditorUtility.OpenFilePanel(
            title: "SFX.json Location",
            extension: "json",
            directory: "Assets");
        
        string outputPath = EditorUtility.SaveFilePanelInProject(
            title: "Save Location",
            defaultName: "SFX",
            extension: "cs",
            message: "Where do you want to save the sfx?");
        
        string classDefinition = string.Empty;

        classDefinition += "public class SFX" + Environment.NewLine;

        classDefinition += "{" + Environment.NewLine;


        SFXList sfxList = SFXList.LoadSFXList(configPath);
        
        foreach (string sound in sfxList.SFX)
        {
            classDefinition += string.Format("\tpublic const string {0} = \"{0}\";\n", sound);
        }

        classDefinition += "}" + Environment.NewLine;
        
        File.WriteAllText(outputPath, classDefinition);
    }
}