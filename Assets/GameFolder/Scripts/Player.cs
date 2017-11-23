using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	void Start () {
		
	}
	
	void Update ()
    {
        //Get key to reset drink
	    if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameManager.Instance().SetNewRecipe();
        }

        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            GameManager.Instance().SetNewRecipe();
        }
	}
}
