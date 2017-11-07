using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class shakeBottle : MonoBehaviour {
    SerialPort serPort;// = new SerialPort("COM4", 9600);

    private Vector3 startPos;
    public float shakeDist;
    public float shakeSpeed;
    private bool shaking;
    private bool movingUp;

	// Use this for initialization
	void Start () {
        serPort = new SerialPort("COM4", 9600);
        serPort.Open();

        startPos = transform.position;
        movingUp = true;
        shaking = false;
	}
	
	// Update is called once per frame
	void Update () {
        int b = serPort.ReadByte();
        Debug.Log("serialPort = " + b);
        if (b > 0)
        {
            shaking = true;
        }
        else
        {
            shaking = false;
        }

        if (shaking)
        {
            Shake();
            Debug.Log("shaking");
        }
        else
        {
            if (transform.position.y > startPos.y)
            {
                transform.Translate(Vector3.down * shakeSpeed);
                movingUp = false;
            }
            else if (transform.position.y < startPos.y)
            {
                transform.Translate(Vector3.up * shakeSpeed);
                movingUp = true;
            }
        }
	}

    private void Shake() {
        if (movingUp)
        {
            if (transform.position.y > startPos.y + shakeDist)
            {
                transform.Translate(Vector3.down * shakeSpeed);
                movingUp = false;
            }
            else
            {
                transform.Translate(Vector3.up * shakeSpeed);
            }
        }
        else
        {
            if (transform.position.y < startPos.y - shakeDist)
            {
                transform.Translate(Vector3.up * shakeSpeed);
                movingUp = true;
            }
            else
            {
                transform.Translate(Vector3.down * shakeSpeed);
            }
        }
      
    }
}
