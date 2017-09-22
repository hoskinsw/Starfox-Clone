using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.SceneManagement;

public class SphereCommands : MonoBehaviour
{
    Vector3 originalPosition;

    // Use this for initialization
    void Start()
    {
        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        GameObject renderPosition = new GameObject();
        renderPosition.name = "RenderPosition";
        renderPosition.transform.position = transform.position;
        GameObject.Find("Full_Level").transform.parent = renderPosition.transform;
        foreach (Transform child in GameObject.Find("Full_Level").transform)
        {
            child.gameObject.SetActive(true);
        }
        //GameObject cube = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));
        //cube.transform.position = this.transform.localPosition;
    }

    void SetReset(bool resetVal)
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        OnSelect();
    }
}
