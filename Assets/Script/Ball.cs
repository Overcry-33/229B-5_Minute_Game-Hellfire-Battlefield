using UnityEngine;

public class Ball : MonoBehaviour
{
    public float forceMultiplier = 1f; // ปรับแรงเพิ่มหรือลดได้

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // ตรวจสอบว่าชนกับกระสุน
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // คำนวณแรงจาก F = ma
            Rigidbody bulletRb = collision.gameObject.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                // แรง = มวลกระสุน * ความเร็วกระสุน
                Vector3 impactForce = bulletRb.mass * bulletRb.velocity * forceMultiplier;

                // ใช้ AddForce แบบ Impulse เพื่อให้ผลทันที
                rb.AddForce(impactForce, ForceMode.Impulse);
            }
        }
    }
}
