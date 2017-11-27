using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator anim;

    private int reset = 0;

	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        //Get key to reset drink and set drink slide animations
        if (Input.GetKeyDown(KeyCode.LeftShift) && reset >= 1)
        {
            anim.SetBool("Playing", false);
            anim.SetBool("Reset", true);
            reset = 0;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameManager.Instance().SetNewRecipe();
            anim.SetBool("Playing", true);
            anim.SetBool("Reset", false);
            reset++;
        }
        else if (Input.GetKeyDown(KeyCode.RightShift))
        {
            //GameManager.Instance().SetNewRecipe();
            anim.SetBool("Playing", false);
            reset = 0;
        }
    }
}
