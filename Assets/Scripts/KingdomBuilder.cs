Material MakeMaterial(Color color)
{
    Shader shader = Shader.Find("Universal Render Pipeline/Lit");

    if (shader == null)
    {
        shader = Shader.Find("Standard");
    }

    if (shader == null)
    {
        Debug.LogError("No supported shader found!");
        return null;
    }

    Material material = new Material(shader);
    material.color = color;

    return material;
}        
