using TMPro;
using UnityEngine;

public class PlayerAttri : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    [SerializeField] private HpUi healthBar;
    [SerializeField] private TextMeshProUGUI WinnerText;

    void Start()
    {
        health = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealthBar(health);
        }
    }

    void FixedUpdate()
    {
        
        if(IsDead())
        {   WinnerText.text = "Left Player Win!";
            GameController gameController = FindFirstObjectByType<GameController>();
            if (gameController != null)
            {
                gameController.GameOver();
            }
            Destroy(this.gameObject);
        }
    }

    public void SetHealth(int healthChange)
    {
        health = Mathf.Clamp(health + healthChange, 0, maxHealth);
        if (healthBar != null)
        {
            healthBar.SetHealthBar(health);
        }
    }

    public bool IsDead()
    {
        return health <= 0;
    }
    
    
}

