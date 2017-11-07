using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Bottle : MonoBehaviour {

    public bool pouring;
    public bool pickedUp;

    public Quaternion pourAngle;
    public Quaternion currentAngle;

    SerialPort serPort;// = new SerialPort("COM4", 9600);

    public Contents currentContent;

    public enum Contents
    {
        //insert drink types
    };

	// Use this for initialization
	void Start ()
    {
        serPort = new SerialPort("COM4", 9600);
        serPort.Open();
    }
	
	// Update is called once per frame
	void Update ()
    {
        int b = serPort.ReadByte();
        Tilt(b);
    }

    public void Tilt(float tiltAmount)
    {
        //changes the angle of the bottle based on the input
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, tiltAmount));
    }

    public void Pour()
    {
        //tests if the current angle is greater that the pour angle
    }

    public bool IsPickedUp()
    {
        //tests if the bottle is picked up based on input
        return false;
    }

    public void SetContent()
    {
        //idk
    }
}
