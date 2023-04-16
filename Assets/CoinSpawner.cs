using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int numberOfCoins = 3;
    public float spawnRadius = 10f;
    public float spawnInterval = 3f; // time interval between spawns
    private float spawnTimer = 0f;

    void Update()
    {
        // Check if it's time to spawn more coins
        if (Time.time > spawnTimer)
        {
            spawnTimer = Time.time + spawnInterval;
            for (int i = 0; i < numberOfCoins; i++)
            {
                Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                Quaternion spawnRotation = Quaternion.Euler(90f, 0f, 0f);
                GameObject newCoin = Instantiate(coinPrefab, spawnPosition, spawnRotation);
                newCoin.transform.parent = transform;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}


