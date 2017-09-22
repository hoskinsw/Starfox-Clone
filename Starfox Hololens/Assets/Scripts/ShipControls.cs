using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour {

    public float xMin = -3.5f;
    public float xMax = 3.5f;
    public float yMin = .5f;
    public float yMax = 3f;
    public float tiltAngle = 20f;
    public float speed = 2f;
    float vert = 0f;
    float horiz = 0f;

    public GameObject gun;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveAndRotate();
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject b = Instantiate(bullet, gun.transform.position, new Quaternion());
            b.GetComponent<Bullet>().direction = Vector3.Normalize(gun.transform.position - transform.position);
        }
    }

    void MoveAndRotate()
    {
        //Using the same vert and horiz variables for both movement and rotation to make sure that they scale together
        //i.e. we want to slow down/speed up rotation and movement together

        float inputVert = Input.GetAxis("Vertical");
        float inputHoriz = Input.GetAxis("Horizontal");

        //this step is arbitrary, I just picked a number that looked good
        SetHoriz(tiltAngle, 50f, inputHoriz);
        SetVert(tiltAngle, 50f, inputVert);

        transform.position += new Vector3(horiz * .2f * Time.deltaTime, vert * .2f * Time.deltaTime, 0);
        //transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax), transform.position.z);

        float xRot = vert > 0 ? 360f - vert : (vert < 0 ? -vert : 0);
        float zRot = horiz > 0 ? horiz : (horiz < 0 ? 360f + horiz : 0);

        Vector3 eulerAngles = new Vector3(xRot, transform.localEulerAngles.y, -zRot);

        transform.localEulerAngles = eulerAngles;
    }

    void SetVert(float max, float step, float input)
    {
        vert += input * step * Time.deltaTime;
        vert = Mathf.Clamp(vert, -max, max);
        if (input == 0 && vert != 0)
            vert = MoveTowards(vert, 0f, step);
        if (Similar(vert, 0f, step * Time.deltaTime))
            vert = 0f;
    }

    void SetHoriz(float max, float step, float input)
    {
        horiz += input * step * Time.deltaTime;
        horiz = Mathf.Clamp(horiz, -max, max);
        if (input == 0 && horiz != 0)
            horiz = MoveTowards(horiz, 0f, step);
        if (Similar(horiz, 0f, step * Time.deltaTime))
            horiz = 0f;
    }

    bool Similar(float curr, float target, float distance)
    {
        return (Mathf.Abs(curr - target)) < distance;
    }

    float MoveTowards(float curr, float target, float step)
    {
        if (curr > target)
            curr -= step * Time.deltaTime;
        else if (curr < target)
            curr += step * Time.deltaTime;
        return curr;
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.GetComponent<ScoreContainer>())
        {
            GetComponent<Player>().SetScoreNumber(coll.gameObject.GetComponent<ScoreContainer>().score);
        }
    }
}
