using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public AudioClip coinSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // The lowpoly character has collided with a coin, so collect it
            CollectCoin(other.gameObject);

            // Coroutine to respawn the coin after a short delay
            StartCoroutine(RespawnCoin(other.gameObject));
        }
    }

    private void CollectCoin(GameObject coin)
{
    ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

    // Increment score
    scoreManager.IncrementScore();

    // Update score text
    scoreManager.UpdateScoreText();

    AudioSource.PlayClipAtPoint(coinSound, transform.position);

    // Destroy the coin object
    Destroy(coin);
}

    private IEnumerator RespawnCoin(GameObject coinPrefab)
{
    // Wait for 3 seconds before respawning the coin
    yield return new WaitForSeconds(3f);

    GameObject Coin = GameObject.FindGameObjectWithTag("Coin");

}


}


