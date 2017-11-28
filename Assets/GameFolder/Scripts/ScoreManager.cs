using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int currentScore = 0;

    // A base score rewarded depending on how close you get to the amount required
    public int scoreBase = 10;

    private DrinkRecipes mixedRecipe;
    private DrinkRecipes currentRecipes;

    public void SetRecipes(DrinkRecipes _mixedRecipes, DrinkRecipes _currentRecipes)
    {
        mixedRecipe = _mixedRecipes;
        currentRecipes = _currentRecipes;

        ScoreCalculation();
    }

    void ScoreCalculation()
    {
        for(int i = 0; i < currentRecipes.ingredients.Length; i++)
        {
            for(int j = 0; j < mixedRecipe.ingredients.Length; j++)
            {
                if(currentRecipes.ingredients[i].mixerName == mixedRecipe.ingredients[j].mixerName)
                {
                    //Score stuff goes here
                }
            }
        }
    }
}
