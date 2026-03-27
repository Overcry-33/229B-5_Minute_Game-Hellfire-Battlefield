using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform Shootpoint;
    public GameObject BulletPrefab;

    public float Speed = 100f;

    InputAction attackAction;

    private void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }
    private void Update()
    {
        if (attackAction.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(
            BulletPrefab,
            Shootpoint.transform.position,
            Quaternion.identity
        );

        bullet.GetComponent<Rigidbody>().AddForce(Shootpoint.forward * Speed, ForceMode.Impulse);
        Destroy(bullet, 5);
    }
}
