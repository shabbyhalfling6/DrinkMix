using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{

    public float baseRotateAngle = 5.0f;

    private float timerInitial = 10.0f;
    private float timeSinceLastPress = 0.0f;

    public bool isPickedUp = false;
    public bool isPouring = false;


	// Use this for initialization
	void Start ()
    {
        timeSinceLastPress = timerInitial;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastPress += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A))
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
