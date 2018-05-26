using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class Bottle : MonoBehaviour
{
    public float minPourAngle = 70.0f;
    public float maxPourAngle = 160.0f;

    private float currentAngle = 0.0f;
    public float pourAmount = 1.0f;

    public Mixers currentContent;
	public int id = 0;

    void Start()
    {
        // Set this bottle scipt to be disabled at the start of the game until the bottle has been picked up
        this.enabled = false;
    }

    void Update ()
    {
        // Check if we're connected to a serial port, else use keyboard input
        if (SerialHolder.serPortOpen)
        {
            // Update the tilt with the angle from the serial port input
            Tilt(SerialHolder.angle[id]);
        }
        else
        {
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
        // NOTE: not sure where these magic numbers are coming from
        currentAngle = currentAngle * 0.7f + tiltAmount * 0.3f;
        // Make sure the bottle can't be tilted past these angles
        currentAngle = Mathf.Clamp(currentAngle, 0.0f, maxPourAngle);

        //changes the angle of the bottle based on the input
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, currentAngle));
    }

    public void Pour()
    {
        //pour the amount of liquid based on the current tilt angle
        //get the scaled angle between the max and min pour angles
        float scaledPourAngle = (currentAngle - minPourAngle) / (maxPourAngle - minPourAngle);

        //get the scaled current amount of liquid leaving the bottle based on the scaled pour angle
        float scaledPourAmount = scaledPourAngle * pourAmount;

        //divide that amount by 0.02 so it's a per frame amount
        scaledPourAmount = scaledPourAmount * 0.02f;

        // NOTE: there's probably a better way to do this
        currentContent.amountRequired += scaledPourAmount;

        // ...and this
        for(int i = 0; i < UIManager.Instance().drinkNames.Length; i++)
        {
            if(this.currentContent.mixerName == UIManager.Instance().drinkNames[i])
            {
                for (int j = 0; j < GameManager.Instance().currentRecipe.ingredients.Length; j++)
                {
                    if (this.currentContent.mixerName == GameManager.Instance().currentRecipe.ingredients[j].mixerName)
                    {
                        UIManager.Instance().percentages[i].text = ((int)(currentContent.amountRequired / GameManager.Instance().currentRecipe.ingredients[j].amountRequired * 100)).ToString() + "  Percent of.." ;
                    }
                }
            }
        }
    }
}
