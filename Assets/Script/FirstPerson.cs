using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    public Transform player;
    float Rotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        float x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        Rotation -= y;
        Rotation = Mathf.Clamp(Rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Rotation, 0f, 0f);

        player.Rotate(Vector3.up * x);
    }
}
