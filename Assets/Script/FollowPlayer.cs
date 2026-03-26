using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 3f; // Set speed in the Inspector
    private Transform playerTarget;

    void Start()
    {
        // Find the player object by its tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTarget = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player GameObject not found! Make sure it has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (playerTarget != null)
        {
            // Move towards the player's position
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);

            // Optional: Make the bot look at the player (for 3D games)
            // transform.LookAt(playerTarget.position); 
        }
    }
}
