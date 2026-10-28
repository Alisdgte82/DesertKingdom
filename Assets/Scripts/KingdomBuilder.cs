
using UnityEngine;

public class KingdomBuilder : MonoBehaviour
{
    [Header("Kingdom Settings")]
    public int buildingCount = 24;
    public int wallCount = 32;

    private Material sandMaterial;
    private Material stoneMaterial;
    private Material palaceMaterial;
    private Material oasisMaterial;

    void Start()
    {
        CreateMaterials();
        CreateDesert();
        CreateRoad();
        CreatePalace();
        CreateWalls();
        CreateBuildings();
        CreateOasis();
        CreateLighting();
        CreateCamera();
    }

    void CreateMaterials()
    {
        sandMaterial = MakeMaterial(
            new Color(0.76f, 0.61f, 0.39f));
        stoneMaterial = MakeMaterial(
            new Color(0.66f, 0.57f, 0.43f));
        palaceMaterial = MakeMaterial(
            new Color(0.88f, 0.78f, 0.59f));
        oasisMaterial = MakeMaterial(
            new Color(0.12f, 0.38f, 0.22f));
    }

    Material MakeMaterial(Color color)
    {
        Material material = new Material(
            Shader.Find("Universal Render Pipeline/Lit"));

        if (material.shader == null)
            material.shader = Shader.Find("Standard");

        material.color = color;
        return material;
    }

    void CreateDesert()
    {
        GameObject ground = GameObject.CreatePrimitive(
            PrimitiveType.Plane);

        ground.name = "Desert Ground";
        ground.transform.localScale =
            new Vector3(12f, 1f, 12f);
        ground.GetComponent<Renderer>().material =
            sandMaterial;
    }

    void CreateRoad()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject road = GameObject.CreatePrimitive(
                PrimitiveType.Cube);

            road.name = "Desert Road";
            road.transform.position =
                new Vector3(-10f + i * 1.8f, 0.03f,
                -8f + Mathf.Sin(i * 0.35f) * 2f);

            road.transform.localScale =
                new Vector3(2f, 0.04f, 1.4f);

            road.GetComponent<Renderer>().material =
                stoneMaterial;
        }
    }

    void CreatePalace()
    {
        CreateBlock("Royal Palace",
            new Vector3(0f, 1.2f, 0f),
            new Vector3(5f, 2.4f, 4f),
            palaceMaterial);

        CreateBlock("Palace Tower Left",
            new Vector3(-1.7f, 2.2f, 0f),
            new Vector3(0.8f, 4.4f, 0.8f),
            palaceMaterial);

        CreateBlock("Palace Tower Right",
            new Vector3(1.7f, 2.2f, 0f),
            new Vector3(0.8f, 4.4f, 0.8f),
            palaceMaterial);

        CreateBlock("Palace Entrance",
            new Vector3(0f, 0.8f, -2.1f),
            new Vector3(1.4f, 1.6f, 0.3f),
            stoneMaterial);
    }

    void CreateWalls()
    {
        for (int i = 0; i < wallCount; i++)
        {
            float angle = i * Mathf.PI * 2f / wallCount;
            float x = Mathf.Cos(angle) * 9f;
            float z = Mathf.Sin(angle) * 7f;

            GameObject wall = GameObject.CreatePrimitive(
                PrimitiveType.Cube);

            wall.name = "Kingdom Wall";
            wall.transform.position =
                new Vector3(x, 0.7f, z);
            wall.transform.localScale =
                new Vector3(1.5f, 1.4f, 0.6f);
            wall.transform.rotation =
                Quaternion.Euler(0f, -angle * Mathf.Rad2Deg,
                0f);

            wall.GetComponent<Renderer>().material =
                stoneMaterial;
        }
    }

    void CreateBuildings()
    {
        for (int i = 0; i < buildingCount; i++)
        {
            float angle = i * 2.39996f;
            float radius = 4f + (i % 4) * 1.1f;

            Vector3 position = new Vector3(
                Mathf.Cos(angle) * radius,
                0.65f,
                Mathf.Sin(angle) * radius);

            CreateBlock("Kingdom Building " + i,
                position,
                new Vector3(1.4f, 1.3f, 1.4f),
                palaceMaterial);
        }
    }

    void CreateOasis()
    {
        GameObject oasis = GameObject.CreatePrimitive(
            PrimitiveType.Cylinder);

        oasis.name = "Oasis";
        oasis.transform.position =
            new Vector3(13f, 0.02f, 10f);
        oasis.transform.localScale =
            new Vector3(4f, 0.04f, 4f);

        oasis.GetComponent<Renderer>().material =
            oasisMaterial;
    }

    void CreateBlock(string objectName,
        Vector3 position, Vector3 scale,
        Material material)
    {
        GameObject block = GameObject.CreatePrimitive(
            PrimitiveType.Cube);

        block.name = objectName;
        block.transform.position = position;
        block.transform.localScale = scale;
        block.GetComponent<Renderer>().material =
            material;
    }

    void CreateLighting()
    {
        RenderSettings.ambientLight =
            new Color(0.65f, 0.61f, 0.53f);

        GameObject sun = new GameObject("Desert Sun");
        Light light = sun.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1.4f;
        sun.transform.rotation =
            Quaternion.Euler(45f, -35f, 0f);
    }

    void CreateCamera()
    {
        GameObject cameraObject = new GameObject(
            "Kingdom Camera");

        Camera camera = cameraObject.AddComponent<Camera>();
        cameraObject.tag = "MainCamera";
        camera.transform.position =
            new Vector3(18f, 20f, -22f);

        camera.transform.LookAt(
            new Vector3(0f, 0f, 0f));

        camera.orthographic = true;
        camera.orthographicSize = 20f;
        cameraObject.AddComponent<AudioListener>();
    }
}
