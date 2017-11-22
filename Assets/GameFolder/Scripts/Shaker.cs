using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Shaker : Bottle
{
    public float baseRotateAngle = 5.0f;
	
	void FixedUpdate ()
    {   
        // Keyboard input
        if(Input.GetKeyDown(KeyCode.A))
        {
            Shake();
        }
	}

    void Shake()
    {
        //get the opposite base angle
        baseRotateAngle *= -1;
        //set the angle
        transform.rotation = Quaternion.Euler(new Vector3(0.0f,0.0f,baseRotateAngle));
    }
}
