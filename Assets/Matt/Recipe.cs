using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {

	public List<string> Recipes = new List<string>();

		//("Martini" "Margarita", "Mojito", "Old Fashioned", "Daiquiri", "Pina Colada", 'Cosmopolitan", Long Island Ice Tea");

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

/*
Psuedo

 - Have a list of drink recipes
 - Each recipe can use a maximum of 6 ingredients
 - Each ingredient needs its own RGB colour code
 - When a drink is selected, the system needs to grab the ingredients that it requires
 - The name of the drink and the required ingredients are then listed on the in-game sheet
 - The LED's are then updated 
*/