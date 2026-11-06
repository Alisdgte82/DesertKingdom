using System.IO;
using UnityEditor;
using UnityEngine;

namespace SultansSands.EditorTools
{
    public static class SultansSandsAssetIntake
    {
        private const string ImportedRoot =
            "Assets/Art/Imported/DesertCourtyard";

        private const string PrefabRoot =
            "Assets/Art/Prefabs/DesertCourtyard";

        [MenuItem("Sultans Sands/Art Pipeline/Validate Imported Architecture")]
        public static void ValidateImportedArchitecture()
        {
            if (!AssetDatabase.IsValidFolder(ImportedRoot))
            {
                Debug.LogWarning("Import folder not found: " + ImportedRoot);
                return;
            }

            string[] guids =
                AssetDatabase.FindAssets("t:GameObject", new[] { ImportedRoot });

            int models = 0;
            int renderers = 0;
            int triangles = 0;

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                GameObject model =
                    AssetDatabase.LoadAssetAtPath<GameObject>(path);

                if (model == null) continue;

                models++;

                foreach (Renderer renderer in
                         model.GetComponentsInChildren<Renderer>(true))
                {
                    renderers++;

                    MeshFilter filter = renderer.GetComponent<MeshFilter>();

                    if (filter != null && filter.sharedMesh != null)
                        triangles += CountTriangles(filter.sharedMesh);

                    SkinnedMeshRenderer skinned =
                        renderer as SkinnedMeshRenderer;

                    if (skinned != null && skinned.sharedMesh != null)
                        triangles += CountTriangles(skinned.sharedMesh);
                }
            }

            Debug.Log(
                "Sultans Sands Report | Models: " + models +
                " | Renderers: " + renderers +
                " | Triangles: " + triangles
            );
        }

        [MenuItem("Sultans Sands/Art Pipeline/Create Staging Prefabs")]
        public static void CreateStagingPrefabs()
        {
            EnsureFolder("Assets/Art");
            EnsureFolder("Assets/Art/Prefabs");
            EnsureFolder(PrefabRoot);

            if (!AssetDatabase.IsValidFolder(ImportedRoot))
            {
                Debug.LogWarning("Import architecture models first.");
                return;
            }

            string[] guids =
                AssetDatabase.FindAssets("t:GameObject", new[] { ImportedRoot });

            int created = 0;

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                GameObject source =
                    AssetDatabase.LoadAssetAtPath<GameObject>(path);

                if (source == null) continue;

                string safeName = source.name;

                foreach (char c in Path.GetInvalidFileNameChars())
                    safeName = safeName.Replace(c, '_');

                string prefabPath = PrefabRoot + "/" + safeName + ".prefab";

                PrefabUtility.SaveAsPrefabAsset(source, prefabPath);
                created++;
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("Created " + created + " staging prefabs.");
        }

        private static int CountTriangles(Mesh mesh)
        {
            int total = 0;

            for (int i = 0; i < mesh.subMeshCount; i++)
            {
                if (mesh.GetTopology(i) == MeshTopology.Triangles)
                    total += (int)mesh.GetIndexCount(i) / 3;
            }

            return total;
        }

        private static void EnsureFolder(string path)
        {
            if (AssetDatabase.IsValidFolder(path)) return;

            string parent = Path.GetDirectoryName(path)
                .Replace("\\", "/");

            string name = Path.GetFileName(path);

            if (!AssetDatabase.IsValidFolder(parent))
                EnsureFolder(parent);

            AssetDatabase.CreateFolder(parent, name);
        }
    }
}
