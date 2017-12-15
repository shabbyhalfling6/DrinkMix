using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class SerialHolder : MonoBehaviour {
	public static SerialPort serPort;
	public static bool serPortOpen = true;
	public static float[] angle=new float[4];

	public string ComPort = "COM6";
    public int port = 22;
    // Use this for initialization
    void Start () {
        System.IO.StreamReader sr;

        try
        {
            sr = new System.IO.StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\serial.txt");
        }
        catch
        {
            serPortOpen = false;
            return;
        }

        
        int.TryParse(sr.ReadLine(), out port);
        ComPort = "COM" + port;
        Debug.Log(ComPort);
		serPort = new SerialPort(ComPort, 9600);

        if (port == 22)
        {

        }

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

	}
	
	// Update is called once per frame
	void Update () {
		if (serPortOpen)
		{
			int b;
			b = serPort.ReadByte();
			int a = b & 63;
			int player = b >> 6;
			angle [player] = (63 - a) * 3.0f;
			Debug.Log("Player"+player+"   "+a);
			//Tilt((221-b)*(180.0f/221.0f));
			//Tilt((63-angle)*3.0f);
		}

	}
}
