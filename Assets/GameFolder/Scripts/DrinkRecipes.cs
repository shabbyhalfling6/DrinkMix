using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Colour
{
    public byte red;
    public byte green;
    public byte blue;
}

public struct Mixers
{
    public string mixerName;

    public float amountRequired;

    public Colour mixerColour;
}

public class DrinkRecipes
{
    public string recipeName = "No Name";

    public Mixers[] ingredients;
}
