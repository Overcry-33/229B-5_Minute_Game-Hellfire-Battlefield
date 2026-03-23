using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject shootPointPrefab;
    [SerializeField] GameObject hitPointPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        RaycastHit hit;
        Debug.DrawRay(shootPoint.position, transform.forward * 30f, Color.red);
        if (Physics.Raycast(shootPoint.position, transform.forward, out hit, 100f))
        {
            Debug.DrawRay(shootPoint.position, transform.forward * hit.distance, Color.green);
            Debug.Log("Ray hits " + hit.collider.name);
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            Instantiate(shootPointPrefab, hit.point, Quaternion.identity);
            Instantiate(hitPointPrefab, hit.point, Quaternion.identity);
        }
        if (hit.collider.name == "E")
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
