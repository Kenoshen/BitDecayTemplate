using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class GenerateTags : MonoBehaviour
{
    [MenuItem("Tools/Generate Tags")]
    public static void CreateTags()
    {
        string outputPath = EditorUtility.SaveFilePanelInProject(
            title: "Save Location",
            defaultName: "Tags",
            extension: "cs",
            message: "Where do you want to save the tags?");
        
        string classDefinition = string.Empty;

        classDefinition += "public class Tags" + Environment.NewLine;

        classDefinition += "{" + Environment.NewLine;


        List<string> tags = new List<string>(InternalEditorUtility.tags);
        foreach (string tag in tags)
        {
            classDefinition += string.Format("\tpublic const string {0} = \"{0}\";\n", tag);
        }

        classDefinition += "}" + Environment.NewLine;
        
        File.WriteAllText(outputPath, classDefinition);
    }
}