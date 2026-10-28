
using UnityEngine;

public class KingdomStartup : MonoBehaviour
{
    void Start()
    {
        if (FindObjectOfType<KingdomBuilder>() == null)
        {
            GameObject kingdom = new GameObject("Kingdom");
            kingdom.AddComponent<KingdomBuilder>();
        }
    }
}
