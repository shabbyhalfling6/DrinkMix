using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDeclaration : MonoBehaviour {

	RecipeController reciCon;

	// Use this for initialization
	void Start () {
		reciCon = GameObject.FindGameObjectWithTag ("RecipeController").GetComponent<RecipeController> ();
		SetRecipes ();	
	}

	void SetRecipes(){

	}
}
