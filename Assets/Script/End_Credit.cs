using UnityEngine;

public class End_Credit : MonoBehaviour
{
    public GameObject UI;

    void OnCollisionEnter()
    {
        UI.SetActive(true);
    }
}
