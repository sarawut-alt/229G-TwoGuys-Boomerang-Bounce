using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    public void GameOver()
    {
        gameOverScreen.SetUpGameOver();
    }
}
