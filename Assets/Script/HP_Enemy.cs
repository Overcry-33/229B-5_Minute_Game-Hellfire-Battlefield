using UnityEngine;

public class HP_Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public int Damage = 25;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")&&collision.collider.GetComponent<Rigidbody>())
        {
            collision.collider.GetComponent<HP_Player>().TakeDamage(Damage);
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");
        Destroy(gameObject);
    }
}
