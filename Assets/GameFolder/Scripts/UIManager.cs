using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text[] ingredientsText;
    public Text[] percentages;
    public Text recipeNameText;
    public Text shiftTimer;
    public Text score;
    public Text gameOverScore;

    public GameObject mainMenuCanvas;
    public GameObject gameOverCanvas;
    public GameObject HUDCanvas;

    public static UIManager instance;
    
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
    }

    public void SetHUD(bool enable)
    {
        HUDCanvas.SetActive(enable);
    }

    public void SetMainMenu(bool enable)
    {
        mainMenuCanvas.SetActive(enable);
    }

    public void SetGameOverMenu(bool enable)
    {
        gameOverCanvas.SetActive(enable);
    }
}
