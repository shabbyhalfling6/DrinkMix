using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int currentScore = 0;

    // A base score rewarded depending on how close you get to the amount required
    public int scoreBase = 10;

    public void SetRecipes(DrinkRecipes _mixedRecipe, DrinkRecipes _currentRecipe)
    {
        ScoreCalculation(_currentRecipe, _mixedRecipe);
    }

    void ScoreCalculation(DrinkRecipes currentRecipe, DrinkRecipes mixedRecipe)
    {
        for(int i = 0; i < currentRecipe.ingredients.Length; i++)
        {
            for(int j = 0; j < mixedRecipe.ingredients.Length; j++)
            {
                if (mixedRecipe.ingredients[j].mixerName == currentRecipe.ingredients[i].mixerName)
                {
                    float currentRecipeAmount = currentRecipe.ingredients[i].amountRequired;
                    float mixedRecipeAmount = mixedRecipe.ingredients[j].amountRequired;

                    float percentage = (mixedRecipeAmount/currentRecipeAmount) * 100;
                    Debug.Log(percentage);
                }
            }
        }
    }
}
