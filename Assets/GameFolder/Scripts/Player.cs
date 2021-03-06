﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator anim;
    private GameObject glass;

    private bool finishedPlaying = false;
    private bool buttonPressed = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

    void Start ()
    {
        glass = this.gameObject;
	}
	
	void Update ()
    {
        if ((Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)) && !buttonPressed)
        {
            Instantiate(glass);
            anim.SetBool("SlideOut", true);
            buttonPressed = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance().SetNewRecipe(true);
            //GameManager.Instance().ResetDrinks(false);
        }

        if(Input.GetMouseButtonDown(1))
        {
            GameManager.Instance().ResetDrinks();
        }

        if(finishedPlaying)
        {
            Destroy(this.gameObject);
        }
    }

    void ResetPlaying()
    {
        anim.SetBool("SlideIn", false);
    }

    void FinishedPlaying()
    {
        finishedPlaying = true;
    }
}
