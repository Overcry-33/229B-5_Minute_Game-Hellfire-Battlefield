using UnityEngine;

public class SlipperyFloor : MonoBehaviour
{
    public float slideForce = 20f; // แรงไถล

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                float mass = rb.mass;

                // ใช้แนวการเคลื่อนที่ของ Player
                Vector3 direction = collision.gameObject.transform.forward;

                // F = m * a
                Vector3 force = direction * mass * slideForce;

                rb.AddForce(force);
            }
        }
    }
}
