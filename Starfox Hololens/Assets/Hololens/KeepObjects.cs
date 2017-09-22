using UnityEngine;
using System.Collections;

public class KeepObjects : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Object.DontDestroyOnLoad(GameObject.Find("Lights"));
        Object.DontDestroyOnLoad(GameObject.Find("Main Camera"));
        Object.DontDestroyOnLoad(GameObject.Find("Spatial Mapping"));
        Object.DontDestroyOnLoad(GameObject.Find("PlacementObject"));
        Object.DontDestroyOnLoad(GameObject.Find("Cursor"));
        Object.DontDestroyOnLoad(GameObject.Find("GestureManager"));
        Object.DontDestroyOnLoad(GameObject.Find("TabManager"));
        Object.DontDestroyOnLoad(GameObject.Find("Scaler"));

    }
}
