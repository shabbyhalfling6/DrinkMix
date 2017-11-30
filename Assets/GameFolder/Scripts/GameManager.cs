using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //the list of bottles in the game
    public Bottle[] bottles;
    public DrinkRecipes[] recipes;
    public Mixers[] mixers;

    //the current recipe displayed
    public DrinkRecipes currentRecipe;

    public Text ingredientsText;
    public Text recipeNameText;

    private ScoreManager score;

    private static GameManager instance;

    public static GameManager Instance()
    {
        if (instance == null)
        {
            Debug.Log("There is no game manager in the scene!");
            return null;
        }
        else
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;    
    }

    void Start ()
    {
        instance = this;

        //initialises all the bottles in the scene
        bottles = FindObjectsOfType(typeof(Bottle)) as Bottle[];
        score = GameObject.Find("GameManager").GetComponent<ScoreManager>();
	}

    public void SetNewRecipe()
    {
        //Set a new recipe from the list of recipes in the recipe controller
        int randNum = Random.Range(0, recipes.Length);
        currentRecipe = recipes[randNum];

        recipeNameText.text = currentRecipe.recipeName;

        ingredientsText.text = "";

        for (int i = 0; i < currentRecipe.ingredients.Length; i++)
        {
            SetBottleContents(i);

            if(currentRecipe.ingredients[i].amountRequired != 0)
                ingredientsText.text += currentRecipe.ingredients[i].amountRequired.ToString() + "oz of " + currentRecipe.ingredients[i].mixerName + "\n\n";
        }

        GetScore();
    }

    void SetBottleContents(int index)
    {
        for(int i = 0; i < bottles.Length; i++)
        {
            bottles[i].currentContent.mixerName = "";
        }

        int k = 0;

        do
        {
            k = Random.Range(0, bottles.Length);
        } while (bottles[k].currentContent.mixerName != "");
        bottles[k].currentContent = currentRecipe.ingredients[index];
        bottles[k].SetBottleColour(bottles[k].currentContent.mixerColour);
    }

    //this reads in the content of the bottles that have been poured and resets them and gets the score
    void GetScore()
    {
        //the recipe that was mixed by the player
        DrinkRecipes mixedRecipes = new DrinkRecipes();
        mixedRecipes.ingredients = new Mixers[bottles.Length];
        mixedRecipes.recipeName = "DrinkMix";

        for (int i = 0; i < bottles.Length; i++)
        {
            mixedRecipes.ingredients[i] = bottles[i].currentContent;
        }

        score.SetRecipes(mixedRecipes, currentRecipe);
    }
}
