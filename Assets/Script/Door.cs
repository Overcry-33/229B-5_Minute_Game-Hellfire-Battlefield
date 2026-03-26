using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject key;

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        if (key == null && other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
