using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraTransform.position);
    }
}
