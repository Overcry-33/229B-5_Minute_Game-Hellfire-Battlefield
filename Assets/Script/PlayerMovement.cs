using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 10f;

    Rigidbody rb;

    InputAction moveInput;
    InputAction jumpInput;

    bool grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveInput = InputSystem.actions.FindAction("Move");
        jumpInput = InputSystem.actions.FindAction("Jump");
        grounded = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = moveInput.ReadValue<Vector2>().x;
        float y = moveInput.ReadValue<Vector2>().y;
        Vector3 forward = Camera.main.transform.right;
        Vector3 right = -Camera.main.transform.forward;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        transform.Translate(y * speed * Time.deltaTime * forward);
        transform.Translate(x * speed * Time.deltaTime * right);

        if (jumpInput.WasPressedThisFrame())
        {
            rb.AddForce(transform.up * jump, ForceMode.Impulse);
            grounded = false;
        }
    }
}
