using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager {

    public int currentScore = 0;

    // A base score rewarded depending on how close you get to the amount required
    public float scoreBase = 10;

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
                    //this seems really bad and there's probably a much easier way to do this that I don't know about but it's 3am and I'm going to bed
                    float difference = mixedRecipe.ingredients[j].amountRequired / currentRecipes.ingredients[i].amountRequired;
                    if(difference > 1)
                    {
                        difference -= (int)difference;
                    }

                    currentScore += (int)(difference * scoreBase);
                }
            }
        }
    }
}
