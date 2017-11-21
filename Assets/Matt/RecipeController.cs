using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeController : MonoBehaviour {

	//public List<string> Drinks = new List<string>();

	public DrinkRecipes[] RecipeList = new DrinkRecipes[4];



		//("Martini" "Margarita", "Mojito", "Old Fashioned", "Daiquiri", "Pina Colada", 'Cosmopolitan", Long Island Ice Tea");

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetIngredients(){
		//Add the change the floats into percentages
		DrinkRecipes Martini = new DrinkRecipes ();
		Martini.DryVemouth = 0.5;
		Martini.Gin = 3;
		RecipeList [1] = Martini;
		DrinkRecipes Margarita = new DrinkRecipes ();
		Margarita.Tequila = 2;
		Margarita.Cointreau = 1;
		Margarita.LimeJuice = 1;
		RecipeList [2] = Martini;
		DrinkRecipes Mojito = new DrinkRecipes ();
		Mojito.WhiteRum = 1.5;
		Mojito.LimeJuice = 1;
		Mojito.SodaWater = 5;
		RecipeList [3] = Martini;
		DrinkRecipes OldFashioned = new DrinkRecipes ();
		OldFashioned.Bourbon = 1.5;
		OldFashioned.AngosturaBitters = 0.5;
		OldFashioned.Water = 0.5;
		RecipeList [4] = Martini;
	}
}

/*
Psuedo

 - Have a list of drink recipes
 - Each recipe can use a maximum of 6 ingredients
 - Each ingredient needs its own RGB colour code
 - When a drink is selected, the system needs to grab the ingredients that it requires
 - The name of the drink and the required ingredients are then listed on the in-game sheet
 - The LED's are then updated to match the colour codes that were previously given to the ingredients
 - When an ingredient is poured, said ingredient is then ticked off the list
