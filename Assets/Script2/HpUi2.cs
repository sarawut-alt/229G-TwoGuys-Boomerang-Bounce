using UnityEngine;
using UnityEngine.UI;

public class HpUi2 : MonoBehaviour
{
    public float Width, Height, Health2, MaxHealth2;

    
    [SerializeField] private RectTransform healthBar;
    
    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth2 = maxHealth;
        
    }
    
    public void SetHealthBar(float health)
    {
        Health2 = health;
        
        float newWidth2 = Health2/MaxHealth2 * Width;

        healthBar.sizeDelta = new Vector2(newWidth2, Height);
    }
}
