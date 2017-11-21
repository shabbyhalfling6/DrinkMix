using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum Mixers
    {
        DryVemouth = 0,
        Gin,
        Tequila,
        Cointreau,
        WhiteRum,
        Bourbon,
        AngosturaBitters,
        VodkaCitron,
        TripleSec,
        Vodka,
        LemonJuice,
        LimeJuice,
        SimpleSyrup,
        SodaWater,
        Water,
        PineappleJuice,
        CoconutCream,
        CranberryJuice,
        GommeSyrup,
        Cola,

        MixersNum
    };

public class GameManager : MonoBehaviour
{
    //the list of bottles in the game
    public Bottle[] bottles = new Bottle[6];
    public DrinkRecipes[] recipes = new DrinkRecipes[(int)Mixers.MixersNum];

    public DrinkRecipes currentRecipe;

	void Start ()
    {
        //initialises all the bottles in the scene
        bottles = FindObjectsOfType(typeof(Bottle)) as Bottle[];
	}

    void SetNewRecipe()
    {
        //Set a new recipe from the list of recipes in the recipe controller
        currentRecipe = recipes[Random.Range(0, recipes.Length)];
    }

    void SetMixers(Mixers[] mixers)
    {
        for (int i = 0; i < mixers.Length; i++)
        {
            //Loop over bottles to check if the mixer is already set to a bottle
            for (int j = 0; j < bottles.Length; j++)
            {
                if (mixers[i] == bottles[j].currentContent)
                {
                    break;
                }
                else if(j == bottles.Length)
                {
                    bottles[i].currentContent = mixers[i];
                }
            }
        }
    }
}
