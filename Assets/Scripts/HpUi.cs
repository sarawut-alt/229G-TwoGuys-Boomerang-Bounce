using UnityEngine;
using UnityEngine.UI;

public class HpUi : MonoBehaviour
{
    public float Width, Height, Health, MaxHealth;

    
    [SerializeField] private RectTransform healthBar;
    
    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
        
    }
    
    public void SetHealthBar(float health)
    {
        Health = health;
        
        float newWidth = Health/MaxHealth * Width;

        healthBar.sizeDelta = new Vector2(newWidth, Height);
    }
}
