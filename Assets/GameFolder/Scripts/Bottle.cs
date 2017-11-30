using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;

public class Bottle : MonoBehaviour
{
    SerialPort serPort;// = new SerialPort("COM4", 9600);

    public bool pouring = false;

    public float minPourAngle = 70.0f;
    public float maxPourAngle = 160.0f;

    private float currentAngle = 0.0f;

    public float minPourAmount = 0.0f;
    public float maxPourAmount = 1.0f;

    public Mixers currentContent;

    Thread thread;
    public int b = 0;
    public int c = 0;
    bool running = true;

    void ThreadFunction()
    {
        byte[] data = new byte[4];
        while (running)
        {
            //b = serPort.Read(data,0,4);
            b = serPort.ReadByte();
           
            c++;
        }
    }

    void Start()
    {
        serPort = new SerialPort("COM8", 9600);
        serPort.Open();
        serPort.DiscardInBuffer();
        //serPort.ReadTimeout = 10;
        serPort.Write("R");

       // thread = new Thread(ThreadFunction);
      //  thread.Start();
    }
    void Update ()
    {
        b = serPort.ReadByte();
        Tilt(b);

        if (Input.GetKey("1"))
        {
            Tilt(5.0f);
        }
        else if (Input.GetKey("2"))
        {
            Tilt(-5.0f);
        }

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

    private void OnApplicationQuit()
    {
        running = false;
    }
}
