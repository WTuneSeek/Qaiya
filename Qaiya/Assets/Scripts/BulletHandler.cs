using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    public int damage;
    public float speed = 8;
    private Rigidbody2D rb;
    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Obstruction"))
        {
            Destroy(gameObject);
        }
    }
}
