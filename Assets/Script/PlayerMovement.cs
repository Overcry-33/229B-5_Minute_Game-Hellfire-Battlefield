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
        Vector2 input = moveInput.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        transform.Translate(move * speed * Time.deltaTime);

        if (jumpInput.triggered && grounded)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            grounded = false;
        }
    }
}
