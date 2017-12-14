﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class Bottle : MonoBehaviour
{
    public bool pouring = false;
    public bool serPortOpen = true;

    public float minPourAngle = 70.0f;
    public float maxPourAngle = 160.0f;

    private float currentAngle = 0.0f;

    public float minPourAmount = 0.0f;
    public float maxPourAmount = 1.0f;

    public Mixers currentContent;
    public Material thisMaterial;
	public int id = 0;
    public int b = 0;

    public string ComPort = "COM6";

    void Start()
    {
        this.enabled = false;
    }

    void Update ()
    {
        if (SerialHolder.serPortOpen)
        {
            Tilt(SerialHolder.angle[id]);
        }
        else
        {
            if (SerialHolder.angle[id] > 15)
            {
                //tilted?
            }

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

    public void SetBottleColour(Colour _colour)
    {
        byte[] colorByte = new byte[4];
        colorByte[0] = (byte)(0x18 | id);
        colorByte[1] = _colour.red;
        colorByte[2] = _colour.green;
        colorByte[3] = _colour.blue;

        if (serPortOpen)
        {
            SerialHolder.serPort.Write(colorByte, 0, colorByte.Length);
        }

        thisMaterial.color = new Color(_colour.red/255.0f, _colour.green/255.0f, _colour.blue/255.0f, 1);
    }
}
