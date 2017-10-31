using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Shaking : MonoBehaviour
{
    SerialPort serPort;// = new SerialPort("COM4", 9600);

    public float baseRotateAngle = 5.0f;

    private float timerInitial = 10.0f;
    private float timeSinceLastPress = 0.0f;

    public bool isPickedUp = false;
    public bool isPouring = false;


	// Use this for initialization
	void Start ()
    {
        serPort = new SerialPort("COM4", 9600);
        serPort.Open();
        timeSinceLastPress = timerInitial;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastPress += Time.deltaTime;

        int b = serPort.ReadByte();

        if (b == 0)
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
