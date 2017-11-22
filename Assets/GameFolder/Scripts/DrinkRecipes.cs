using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Mixers
{
    public string mixerName;

    public float amountRequired;
}

public class DrinkRecipes
{
    public string recipeName = "No Name";

    public Mixers[] ingredients;
}
