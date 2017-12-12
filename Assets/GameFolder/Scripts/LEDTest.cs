using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class LEDTest : MonoBehaviour {

    public SerialPort serPort;
    public string ComPort = "COM6";
    public byte[] colorByte;

    // Use this for initialization
    void Start () {


        serPort = new SerialPort(ComPort, 9600);

        //tests if the serial port can be connected to
        try
        {
            serPort.Open();
        }
        catch (Exception e)
        {
            Debug.Log("Could not open serial port: " + e.Message);
        }

        //byte[] colorByte = new byte[3];
        //colorByte[0] = 0;
        //colorByte[1] = 255;
        //colorByte[2] = 0;

        serPort.Write(colorByte, 0, colorByte.Length);


    }

    // Update is called once per frame
    void Update () {
		
	}
}
