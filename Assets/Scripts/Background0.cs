using UnityEngine;
using UnityEngine.UI;

public class Background0 : MonoBehaviour
{
    public Button StartButton;

    private void Awake()
    {
        StartButton.onClick.AddListener(() => {
            // Load the next scene when the button is clicked
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
            
        });
    }
}
