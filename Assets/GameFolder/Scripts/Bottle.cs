using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Bottle : MonoBehaviour
{
    public bool pouring = false;
    public bool pickedUp = false;

    public float minPourAngle = 70.0f;
    public float maxPourAngle = 160.0f;

    private float currentAngle = 0.0f;

    public float minPourAmount = 0.0f;
    public float maxPourAmount = 1.0f;

    public float currentPourAmount = 0.0f;

    public Mixers currentContent;
	
	void FixedUpdate ()
    {
        //Keyboard Inputs
        if (Input.GetKey("1"))
        {
            Tilt(5.0f);
        }
        else if (Input.GetKey("2"))
        {
            Tilt(-5.0f);
        }

        //Test if currently pouring
        if (currentAngle >= minPourAngle)
        {
            Pour();
        }
    }

    //Used to set rotation of the bottle on the z axis
    public void Tilt(float tiltAmount)
    {
        currentAngle += tiltAmount;
        currentAngle = Mathf.Clamp(currentAngle, 0.0f, maxPourAngle);

        //changes the angle of the bottle based on the input
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, currentAngle));
    }

    public void Pour()
    {
        //pour the amount of liquid based on the current tilt angle
        //get the scaled angle between the max and minn pour angles
        float scaledPourAngle = (currentAngle - minPourAngle) / (maxPourAngle - minPourAngle);

        //get the scaled current amount of liquid leaving the bottle based on the scaled pour angle
        float scaledPourAmount = scaledPourAngle * maxPourAmount;

        //divide that amount by 0.02 so it's a per frame amount
        scaledPourAmount = scaledPourAmount * 0.02f;

        Debug.Log(scaledPourAmount);
    }
}
