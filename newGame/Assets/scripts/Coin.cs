using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public bool destroyed = false;

    // Check if the player touches a coin, and increase the score accordingly
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !destroyed)
        {
            Respawn.respawnPoint = transform.position;
            destroyed = true;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(this.gameObject);
            ScoreManager.instance.ChangeScore(coinValue);
        }
    }
}
