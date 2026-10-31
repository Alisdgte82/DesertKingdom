
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.IO;

[InitializeOnLoad]
public static class ProjectBootstrap
{
    static ProjectBootstrap()
    {
        EditorApplication.delayCall += SetupProject;
    }

    static void SetupProject()
    {
        const string folder = "Assets/Scenes";
        const string scenePath = folder + "/Main.unity";

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        if (!File.Exists(scenePath))
        {
            Scene scene = EditorSceneManager.NewScene(
                NewSceneSetup.EmptyScene,
                NewSceneMode.Single
            );

            GameObject kingdom = new GameObject("Kingdom");
            kingdom.AddComponent<KingdomStartup>();

            EditorSceneManager.SaveScene(scene, scenePath);
        }

        EditorBuildSettings.scenes = new[]
        {
            new EditorBuildSettingsScene(scenePath, true)
        };

        PlayerSettings.productName = "Sultans Sands";
        PlayerSettings.SetApplicationIdentifier(
            BuildTargetGroup.Android,
            "com.sultanssands.desertkingdom"
        );

        AssetDatabase.SaveAssets();
        Debug.Log("Sultans Sands project setup completed.");
    }
}
