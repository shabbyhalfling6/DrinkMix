using System.Collections.Generic;
using UnityEngine;

public class RecipeController : MonoBehaviour {

    public TextAsset recipesInfo;

    public string[] lines;
    public string[] info;

    private void Start()
    {
        //reads in all lines of data from the .csv file
        lines = recipesInfo.text.Split("\n"[0]);

        //set the size of the recipes array in the GameManager to how many recipes we have
        GameManager.Instance().recipes = new DrinkRecipes[lines.Length];
       
        //loop over the lines to read in the recipes from the .csv file
        for (int i = 0; i < lines.Length; i++)
        {
            ReadInRecipeInfo(lines[i], i);
        }
    }

    void ReadInRecipeInfo(string infoLine, int index)
    {
        //Read in the line for the current recipe being read in and save to the info array
        info = infoLine.Split(","[0]);

        //the first entry in the info array will be the name of the recipe
        string name = info[0];

        //create a temporary DrinkRecipe class to read in the info and feed it to the GameManager recipes array
        DrinkRecipes readIn = new DrinkRecipes();
        readIn.recipeName = name;

        //set the size of the ingredients array to the amount that was read in at the first line
        // -1 to the size as the first entry in the line is an empty cell


        Mixers[] tempMixers = new Mixers[6];

        int size = 0;

        //loop over the rest of the lines data which will be the ingredients for the recipe
        for (int i = 1; i < info.Length; i++)
        {
            float amount = float.Parse(info[i]);

            //if the amount read in was 0 don't worry about add saving the ingredient, 
            //this is so we know how many and what ingredients we have
            if (amount != 0)
            {
                //create a temporary Mixer class to feed back into the Ingredients list on the Recipe class
                Mixers readInMixer = new Mixers();
                //Set it's name to the corrisponding name in the GameManager mixer array (this could be better)
                readInMixer.mixerName = GameManager.Instance().bottles[i - 1].currentContent.mixerName;
                //Set the amount required for that ingredient based on what was read in
                readInMixer.amountRequired = amount;

                tempMixers[size] = readInMixer;
                size++;
            }
        }

        readIn.ingredients = new Mixers[size];

        for(int i = 0; i < readIn.ingredients.Length; i++)
        {
            if(tempMixers != null)
            {
                readIn.ingredients[i] = tempMixers[i];
            }
        }

        //Save the recipe to the GameManager's recipe array
        GameManager.Instance().recipes[index] = readIn;
    }
}