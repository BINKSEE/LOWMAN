using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;

    private Transform playerTransform;

    // Variables for raycast detection
    public float raycastDistance = 1f;
    public LayerMask obstacleLayer;
    private bool obstacleDetected;
    private Vector3 obstacleAvoidanceDirection;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            // Raycast detection for obstacles
            RaycastHit hit;
            Vector3 raycastDirection = transform.forward;

            if (Physics.Raycast(transform.position, raycastDirection, out hit, raycastDistance, obstacleLayer))
            {
                obstacleDetected = true;
                obstacleAvoidanceDirection = transform.right * Mathf.Sign(Random.Range(-1f, 1f));
            }
            else
            {
                obstacleDetected = false;
            }

            // Avoid obstacles
            if (obstacleDetected)
            {
                transform.Rotate(obstacleAvoidanceDirection * 45f * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // End the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}


