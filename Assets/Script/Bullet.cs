using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HP_Enemy>())
        {
            other.GetComponent<HP_Enemy>().TakeDamage(Damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HP_Enemy>())
        {
            collision.gameObject.GetComponent<HP_Enemy>().TakeDamage(Damage);
        }
    }
}
