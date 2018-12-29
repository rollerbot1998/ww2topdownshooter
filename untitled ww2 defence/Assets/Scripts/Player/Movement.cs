using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
