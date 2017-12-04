using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ingredientsText;
    public Text recipeNameText;

    //put the other UI elements here so you can manage them

    private GameManager gameManager;

    private static UIManager instance;

    public static UIManager Instance()
    {
        if (instance == null)
        {
            Debug.Log("There is no UI manager in the scene!");
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

        gameManager = GameManager.Instance();
    }
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            //enable the player controls and set the game to running
            gameManager.player.enabled = true;
            gameManager.gameRunning = true;
            //main menu disable
        }
	}
}
