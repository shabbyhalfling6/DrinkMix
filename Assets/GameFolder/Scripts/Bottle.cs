using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class Bottle : MonoBehaviour
{
    public float minPourAngle = 70.0f;
    public float maxPourAngle = 160.0f;

    private float currentAngle = 0.0f;

    public Mixers currentContent;
    public string ingredientName;

	public int id = 0;

    void Start()
    {
        // Set this bottles ingredient name when the game starts. Will be the same the whole game
        currentContent.mixerName = ingredientName;
        // Set this bottle scipt to be disabled at the start of the game until the bottle has been picked up
        this.enabled = false;
    }

    void Update ()
    {
        // Check if we're connected to a serial port, else use keyboard input
        if (SerialHolder.serPortOpen)
        {
            // Update the tilt with the angle from the serial port input
            Tilt(SerialHolder.angle[id]);
        }
        else
        {
            if (Input.GetKey("1"))
            {
                float tempF = currentAngle += 5.0f;
                Tilt(tempF);
            }
            else if (Input.GetKey("2"))
            {
                float tempF = currentAngle -= 5.0f;
                Tilt(tempF);
            }
        }
    }

    private void FixedUpdate()
    {
        //Test if the bottle is tilted enough to be pouring
        if (currentAngle >= minPourAngle)
        {
            Pour();
        }
    }

    //Used to set rotation of the bottle on the z axis
    public void Tilt(float tiltAmount)
    {
        // NOTE: not sure where these magic numbers are coming from
        currentAngle = currentAngle * 0.7f + tiltAmount * 0.3f;
        // Make sure the bottle can't be tilted past these angles
        currentAngle = Mathf.Clamp(currentAngle, 0.0f, maxPourAngle);

        //changes the angle of the bottle based on the input
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, currentAngle));
    }

    public void Pour()
    {
        currentContent.amountRequired += Time.deltaTime;
    }
}
