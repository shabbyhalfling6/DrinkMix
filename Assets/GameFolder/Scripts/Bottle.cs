using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;

public class Bottle : MonoBehaviour
{
    SerialPort serPort;

    public bool pouring = false;
    public bool serPortOpen = true;

    public float minPourAngle = 70.0f;
    public float maxPourAngle = 160.0f;

    private float currentAngle = 0.0f;

    public float minPourAmount = 0.0f;
    public float maxPourAmount = 1.0f;

    public Mixers currentContent;

    public int b = 0;

    void Start()
    {
        serPort = new SerialPort("COM6", 9600);

        //tests if the serial port can be connected to
        try
        {
            serPort.Open();
        }
        catch (Exception e)
        {
            Debug.Log("Could not open serial port: " + e.Message);
            serPortOpen = false;
        }

        this.enabled = false;
    }
    void Update ()
    {
        if (serPortOpen)
        {
            b = serPort.ReadByte();
            Tilt(b);
        }

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
        currentAngle = currentAngle * 0.7f + tiltAmount * 0.3f;
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

        currentContent.amountRequired += scaledPourAmount;
    }

    public void SetBottleColour(Colour _colour)
    {
        byte[] colour = new byte[3];
        colour[0] = _colour.red;
        colour[1] = _colour.green;
        colour[2] = _colour.blue;

        if (serPortOpen)
        {
            serPort.Write(colour, 0, colour.Length);
        }
    }

    void OnApplicationQuit()
    {
        Colour black = new Colour();
        black.red = 0;
        black.green = 0;
        black.blue = 0;

        SetBottleColour(black);
    }
}
