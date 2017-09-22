using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    public float speed = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //we will turn this off for hololens version (maybe, might make it a table top version of the game
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
	}
}
