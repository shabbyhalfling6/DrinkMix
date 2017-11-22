using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Mixers
{
    public string mixerName;

    public float amountRequired;
}

public class DrinkRecipes : MonoBehaviour
{
    public string RecipeName = "No Name";
    
    public Mixers[] ingredients = new Mixers[16];
}
