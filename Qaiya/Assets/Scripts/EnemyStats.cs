using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health;
    public int damage;
    
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int takenDamage)
    {
        health -= takenDamage;
    }
}
