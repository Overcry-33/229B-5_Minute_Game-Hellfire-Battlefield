using UnityEngine;

public class LookatTaget : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        this.transform.LookAt(target.position);
    }
}
