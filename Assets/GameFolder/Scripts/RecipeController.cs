using System.Collections.Generic;
using UnityEngine;

public class RecipeController : MonoBehaviour {

    public TextAsset recipesInfo;

    public string[] lines;
    public string[] names;
    public string[] colours;
    public string[] info;

    private void Start()
    {
        //reads in all lines of data from the .csv file
        lines = recipesInfo.text.Split("\n"[0]);

        //set the size of the recipes array in the GameManager to how many recipes we have
        // -2 to the size as the first and second lines of the .csv are for mixers, not recipes
        GameManager.Instance().recipes = new DrinkRecipes[lines.Length - 2];

        //Read in the mixers from the .csv file
        ReadInMixerInfo(lines[0], lines[1]);
       
        //loop over the remaining lines to read in the recipes from the .csv file
        //starts at 2 as the first line is the mixer names
        for (int i = 2; i < lines.Length; i++)
        {
            ReadInRecipeInfo(lines[i], i);
        }
    }

    void ReadInMixerInfo(string nameLine, string colour)
    {
        //Read in the line with all the mixer names and save them to the names array
        names = nameLine.Split(","[0]);
        colours = colour.Split(","[0]);

        //set the size of the mixer array in the GameManager to how many we read in
        // -1 to the size as the first entry in the line is an empty cell
        GameManager.Instance().mixers = new Mixers[names.Length - 1];


        //loop over the read in mixer names and add them to the mixer array in the GameManager
        //loop starts at 1 to skip empty cell
        for (int i = 1; i < names.Length; i++)
        {
            //create a temporary Mixer to set values to and to feed it back into the GameManager array
            Mixers readIn = new Mixers();
            readIn.mixerName = names[i];
            Colour colourReadIn = new Colour();

            int j = i;
            colourReadIn.red = byte.Parse(colours[j]);
            j++;
            colourReadIn.green = byte.Parse(colours[j]);
            j++;
            colourReadIn.blue = byte.Parse(colours[j]);

            readIn.mixerColour = colourReadIn;

            //set an entry in the GameManagers array of mixers to the mixer we just read in
            //"i-1" because we started the loop at 1
            GameManager.Instance().mixers[i-1] = readIn;
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
                readInMixer.mixerName = GameManager.Instance().mixers[i - 1].mixerName;
                readInMixer.mixerColour = GameManager.Instance().mixers[i - 1].mixerColour;
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
        // -2 to the index as the first two line of the .csv are for mixers not recipes
        GameManager.Instance().recipes[index - 2] = readIn;
    }
}