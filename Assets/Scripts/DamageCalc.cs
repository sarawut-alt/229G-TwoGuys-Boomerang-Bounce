
using UnityEngine;


public class DamageCalc : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {     
            PlayerAttri player = other.GetComponent<PlayerAttri>();

            if (player != null)
            {
                
                player.SetHealth(-damage);
                Destroy(this.gameObject);
            }
        }
        if(other.CompareTag("Player"))
        {     
            PlayerAttri2 player2 = other.GetComponent<PlayerAttri2>();

            if (player2 != null)
            {
                
                player2.SetHealth(-damage);
                Destroy(this.gameObject);
            }
        }
        if(other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
