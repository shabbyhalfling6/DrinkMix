using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour {

    public bool pouring;
    public bool pickedUp;

    public Quaternion pourAngle;
    public Quaternion currentAngle;

    public Contents currentContent;

    public enum Contents
    {
        //insert drink types
    };

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Tilt()
    {
        //changes the angle of the bottle based on the input
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
