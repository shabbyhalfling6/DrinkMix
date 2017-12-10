using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int currentScore = 0;

    // A base score rewarded depending on how close you get to the amount required
    public int greatScore = 10;
    public int goodScore = 5;
    public int okScore = 2;
    public int badScore = 0;

    //percentage of how close it is to the recipe
    public int greatCloseness = 10;
    public int goodCloseness = 20;
    public int okCloseness = 35;
    public int badCloseness = 100;

    public int wrongIngredientDeduction = 2;
    public float totalPercentage = 0.0f;

    public void SetRecipes(DrinkRecipes _mixedRecipe, DrinkRecipes _currentRecipe)
    {
        ScoreCalculation(_currentRecipe, _mixedRecipe);
    }

    void ScoreCalculation(DrinkRecipes currentRecipe, DrinkRecipes mixedRecipe)
    {
        //reset the total percentage before doing the score calculations
        totalPercentage = 0.0f;

        for(int i = 0; i < currentRecipe.ingredients.Length; i++)
        {
            for(int j = 0; j < mixedRecipe.ingredients.Length; j++)
            {
                if (mixedRecipe.ingredients[j].mixerName == currentRecipe.ingredients[i].mixerName)
                {
                    float currentRecipeAmount = currentRecipe.ingredients[i].amountRequired;
                    float mixedRecipeAmount = mixedRecipe.ingredients[j].amountRequired;

                    float percentage = (mixedRecipeAmount/currentRecipeAmount) * 100;

                    totalPercentage += percentage / currentRecipe.ingredients.Length;
                }
                else if(j == mixedRecipe.ingredients.Length)
                {
                    //deduct points if the player didn't pour an ingredient or poured the wrong one
                    currentScore -= wrongIngredientDeduction;
                }
            }
        }

        if (totalPercentage > 100)
        {
            totalPercentage -= 100;
        }
        else
        {
            totalPercentage = 100 - totalPercentage;
        }

        if (totalPercentage <= greatCloseness)
            currentScore += greatScore;
        else if (totalPercentage <= goodCloseness)
            currentScore += goodScore;
        else if (totalPercentage <= okCloseness)
            currentScore += okScore;
        else
            currentScore += badScore;

        UIManager.Instance().score.text = "$" + currentScore.ToString();
    }
}
