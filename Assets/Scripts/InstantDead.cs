using UnityEngine;

public class InstantDead : MonoBehaviour
{
    public int damage = 1000;
    
    //if contact with player, call TakeDamage
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {     
            PlayerAttri player = other.GetComponent<PlayerAttri>();

            if (player != null)
            {
                Debug.Log("Player hit by instant death object");
                player.SetHealth(-damage);
            }
        }
        if (other.CompareTag("Player"))
        {     
            PlayerAttri2 player2 = other.GetComponent<PlayerAttri2>();

            if (player2 != null)
            {
                Debug.Log("Player hit by instant death object");
                player2.SetHealth(-damage);
            }
        }

        if(other.CompareTag("Projectile"))
        {
            // Destroy the projectile
            Destroy(other.gameObject);
        }
        
    }
}
