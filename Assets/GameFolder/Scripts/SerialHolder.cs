using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class SerialHolder : MonoBehaviour
{
    public static SerialPort serPort;
	public static bool serPortOpen = true;
    //stores all the angles of all of the bottles
	public static float[] angle = new float[4];

	public string ComPort = "COM6";
    public int port = 22;

    void Start ()
    {
        System.IO.StreamReader sr;

        // tests if the serial.txt file is in MyDocuments to read off
        // TODO: look at moving this file into the project files
        try
        {
            // NOTE: make sure this file is in MyDocuments for the controller to work
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
		serPort = new SerialPort(ComPort, 115200);

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
	
	void Update ()
    {
		if (serPortOpen)
		{
			int b;
			b = serPort.ReadByte();
			int a = b & 63;
			int player = b >> 6;
			angle [player] = (63 - a) * 3.0f;
			Debug.Log("Player"+player+"   "+a);
            Debug.Log(GetIntBinaryString(b));
		}
	}

    static string GetIntBinaryString(int n)
    {
        char[] b = new char[32];
        int pos = 31;
        int i = 0;

        while (i < 32)
        {
            if ((n & (1 << i)) != 0)
            {
                b[pos] = '1';
            }
            else
            {
                b[pos] = '0';
            }
            pos--;
            i++;
        }
        return new string(b);
    }
}
