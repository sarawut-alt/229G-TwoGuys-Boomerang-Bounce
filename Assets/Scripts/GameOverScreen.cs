using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameOverScreen : MonoBehaviour
{
    public Button CreditsButton;
    
 
    public void SetUpGameOver()
    {
        gameObject.SetActive(true);
    }

    public void CreditScreen()
    {
        Debug.Log("Credits Button Pressed");
        SceneManager.LoadScene("Credits");
    }

    
}