using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

    public float speed = 10f;
    public float lowLimit  = 50f;
    public float highLimit = 250f;

    public float ZoomAmount = 0f;
    public float y = 0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //float translation = Input.GetAxis("Vertical") * speed;
        ZoomAmount = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, 0, ZoomAmount * speed);

        if (transform.position.y < lowLimit)
        {
            y = lowLimit - transform.position.y;

            transform.Translate(0, y, 0);
        }

        if (transform.position.y > highLimit)
        {
            y = highLimit - transform.position.y;

            transform.Translate(0, y, 0);
        }

    }
}
