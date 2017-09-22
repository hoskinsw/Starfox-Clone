using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float timeAlive = 0.0f;
    float timeToDeath = 4.0f;

    public Vector3 direction;
    Vector3 prevPos;
    Vector3 startPoint;

    void Start()
    {
        startPoint = transform.position;
    }

	// Update is called once per frame
	void Update () {
        timeAlive += Time.deltaTime;
        if (timeAlive >= timeToDeath)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + (direction * 20f * Time.deltaTime));
        //Debug.DrawRay(startPoint, (transform.position - startPoint));
        //Debug.DrawLine(transform.position, transform.position + (direction * 20f * Time.deltaTime));
        RaycastHit raycast;
        bool didHit = Physics.Linecast(transform.position, transform.position + (direction * 20f * Time.deltaTime), out raycast);
        if(didHit && raycast.transform.gameObject.name.Equals("Target"))
        {
            raycast.transform.gameObject.GetComponent<Enemy>().health--;
            Destroy(this.gameObject);
        }
    }
}
