using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //the list of bottles in the game
    public Bottle[] bottles;
    public DrinkRecipes[] recipes;
    public Mixers[] mixers;

    public DrinkRecipes currentRecipe;

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
	}

    void SetNewRecipe()
    {
        //Set a new recipe from the list of recipes in the recipe controller
        int randNum = Random.Range(0, recipes.Length);
        currentRecipe = recipes[randNum];
    }

    void SetBottleContents()
    {
        for (int i = 0; i < currentRecipe.ingredients.Length; i++)
        {
            for (int j = 0;  j < bottles.Length; j++)
            {
                bottles[j].currentContent.mixerName = "";
            }

            int k = 0;

            do
            {
                k = Random.Range(0, bottles.Length);
            } while (bottles[k].currentContent.mixerName != "");
            bottles[k].currentContent = currentRecipe.ingredients[i];
        }
    }
}
