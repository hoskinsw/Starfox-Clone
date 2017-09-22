using UnityEngine;

public class WorldCursor : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    // Use this for initialization
    void Start()
    {
        // Grab the mesh renderer that's on the same object as this script.
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram...

            // Display the cursor mesh.
            meshRenderer.enabled = true;
            // Move the cursor to the point where the raycast hit.
            this.transform.position = hitInfo.point;
            // Rotate the cursor to hug the surface of the hologram.
            this.transform.rotation =
                Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
        else
        {
            // If the raycast did not hit a hologram, hide the cursor mesh.
            meshRenderer.enabled = false;
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    //GameObject.Find("Cursor").SetActive(false);
        //    //GameObject.Find("PlacementObject").SetActive(true);
        //    GameObject.Find("PlacementObject").transform.position = pos.transform.position;
        //    //Quaternion toQuat = Camera.main.transform.localRotation;
        //    //toQuat.x = 0;
        //    //toQuat.z = 0;
        //    //GameObject.Find("PlacementObject").transform.parent.rotation = toQuat;
        //    foreach (Transform child in GameObject.Find("PlacementObject").transform)
        //    {
        //        child.gameObject.SetActive(true);
        //    }
        //}
    }
}
