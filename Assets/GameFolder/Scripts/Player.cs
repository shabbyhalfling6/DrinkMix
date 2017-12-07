using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator anim;
    private Transform startPos;
    private GameObject glass;

    private bool finishedPlaying = false;
    private bool buttonPressed = false;

	void Start ()
    {
        anim = GetComponent<Animator>();
        glass = this.gameObject;
	}
	
	void Update ()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !buttonPressed)
        {
            Instantiate(glass);
            anim.SetBool("SlideOut", true);
            buttonPressed = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameManager.Instance().SetNewRecipe(true);
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
