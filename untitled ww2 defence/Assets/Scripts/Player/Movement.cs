using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    float xSpeed = 0;
    float ySpeed = 0;


	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //reset player speed
         xSpeed = 0;
         ySpeed = 0;

        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //player movement
        if (Input.GetKey("w"))
        {
            ySpeed = 1;
        }
        if (Input.GetKey("s"))
        {
            ySpeed = -1;
        }
        if (Input.GetKey("a"))
        {
            xSpeed = -1;
        }
        if (Input.GetKey("d"))
        {
            xSpeed = 1;
        }


        transform.position = transform.position + new Vector3(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0); 

    }

    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * -90);
    }

    void RotateRight()
    {
        transform.Rotate(Vector3.forward * 90);
    }
}
