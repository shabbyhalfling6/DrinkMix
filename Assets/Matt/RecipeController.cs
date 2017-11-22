using System.Collections.Generic;
using UnityEngine;

public class RecipeController : MonoBehaviour {

	//This script will read in the recipes and add them to the recipe list in the game manager

	public DrinkRecipes[] RecipeList = new DrinkRecipes[4];

	void SetIngredients()
    {
        //temporary code
        int tempNum = 2;
		//Add the change the floats into percentages
		DrinkRecipes Martini = new DrinkRecipes ();
        for (int i = 0; i < tempNum; i++)
        {
            Martini.ingredients[tempNum].mixerName = "Placeholder Name";
        }

        for (int i = 0; i < RecipeList.Length; i++)
        {
            GameManager.Instance().recipes[i] = RecipeList[i];
        }
	}
}