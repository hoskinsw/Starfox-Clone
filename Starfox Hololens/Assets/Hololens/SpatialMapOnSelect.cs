using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpatialMapOnSelect : MonoBehaviour
{
    //public Scaling scaler;
    public GameObject cursor;
    static bool placed = false;

    // Called by GazeGestureManager when the user performs a Select gesture
    //Create script to attach to Spatial Map objects
    //When clicked they will get the World Cursor object and get it's position and return it
    //Pass this position to whatever needs to be placed and done
    private void Start()
    {
        //cursor = GameObject.Find("Cursor");
        //scaler = GameObject.Find("Scaler").GetComponent<Scaling>();
        Debug.Log("Started");
        placed = false;
    }

    //ToDo: Centers the object correctly but doesnt scale it
    //Need to scale after adding objects to DataHolder
    void OnSelect()
    {
        Debug.Log("select recognized");

        if (!placed)
        {
            Debug.Log("!placed recognized");

            //if (counter == 0)
            //{
            //    Debug.Log("entered counter0");
            //GameObject.Find("Spatial Mapping").GetComponent<SpatialMapping>().DrawVisualMeshes = !GameObject.Find("Spatial Mapping").GetComponent<SpatialMapping>().DrawVisualMeshes;
            GameObject renderPosition = new GameObject();
            renderPosition.name = "RenderPosition";
            renderPosition.transform.position = cursor.transform.position;
            GameObject.Find("Full_Level").transform.parent = renderPosition.transform;
            foreach(Transform child in GameObject.Find("Full_Level").transform)
            {
                child.gameObject.SetActive(true);
            }

            placed = true;

            //}
            //else if (counter == 1)
            //{
            //    sp = scaler.Point2();
            //    GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //    g.transform.position = sp;
            //    g.transform.localScale /= 10f;
            //    g.GetComponent<Renderer>().material.color = Color.blue;
            //    float y = fp.y;
            //    Vector3 pp = (fp + sp) / 2;
            //    pp.y = y;
            //    Debug.Log(pp + " " + fp + " " + sp);

            //    this.gameObject.transform.position = pp;

            //    placed = true;
            //}
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("z"))
            OnSelect();
    }
}
