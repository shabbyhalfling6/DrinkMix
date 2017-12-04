﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //the list of bottles in the game
    public Bottle[] bottles;
    public BottlePickup[] bottlePickups;
    public DrinkRecipes[] recipes;
    public Mixers[] mixers;

    public Player player;
    private ScoreManager score;

    //the current recipe displayed
    public DrinkRecipes currentRecipe;

    public float gameTimer = 60.0f;
    public float gameOverTimer = 20.0f;

    private UIManager uiManager;
    public GameState currentGameState;

    public enum GameState
    {
        mainMenu,
        gameRunning,
        gameOver,

        gameStateNum
    }

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

    void Start()
    {
        instance = this;

        //initialises all the bottles in the scene
        bottles = FindObjectsOfType(typeof(Bottle)) as Bottle[];
        score = this.GetComponent<ScoreManager>();

        bottlePickups = new BottlePickup[bottles.Length];

        for (int i = 0; i < bottles.Length; i++)
        {
            bottlePickups[i] = bottles[i].gameObject.GetComponent<BottlePickup>();
            bottlePickups[i].enabled = false;
        }

        uiManager = UIManager.Instance();
        uiManager.SetHUD(false);
        uiManager.SetMainMenu(true);
        currentGameState = GameState.mainMenu;
	}

    void Update()
    {
        switch (currentGameState)
        {
            case GameState.mainMenu:
            {
                if(Input.GetKeyDown(KeyCode.RightShift))
                {
                    player.enabled = true;
                    for(int i = 0; i < bottlePickups.Length; i++)
                    {
                        bottlePickups[i].enabled = true;
                    }

                    SetNewRecipe();

                    uiManager.SetMainMenu(false);
                    uiManager.SetHUD(true);
                    currentGameState = GameState.gameRunning;
                }
                break;
            }
            case GameState.gameRunning:
            {
                gameTimer -= Time.deltaTime;
                if (gameTimer <= 0.0f)
                {
                    currentGameState = GameState.gameOver;

                    for (int i = 0; i < bottlePickups.Length; i++)
                    {
                        bottlePickups[i].enabled = false;
                    }

                    uiManager.SetGameOverMenu(true);
                    uiManager.SetHUD(false);
                    player.enabled = false;
                }

                break;
            }
            case GameState.gameOver:
            {
                gameOverTimer -= Time.deltaTime;
                if(gameOverTimer <= 0.0f)
                {
                    // re load game scene
                    SceneManager.LoadScene(0);
                }
                break;
            }
        }
    }

    public void SetNewRecipe()
    {
        //Set a new recipe from the list of recipes in the recipe controller
        int randNum = Random.Range(0, recipes.Length);
        currentRecipe = recipes[randNum];

        uiManager.recipeNameText.text = currentRecipe.recipeName;

        uiManager.ingredientsText.text = "";

        for (int i = 0; i < currentRecipe.ingredients.Length; i++)
        {
            SetBottleContents(i);

            if(currentRecipe.ingredients[i].amountRequired != 0)
                uiManager.ingredientsText.text += currentRecipe.ingredients[i].amountRequired.ToString() + "oz of " + currentRecipe.ingredients[i].mixerName + "\n\n";
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
