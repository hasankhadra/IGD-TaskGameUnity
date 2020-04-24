using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] GameObject go;
    public bool destroyed = false;

    // Check if the player collided with the gem 
    // destroy the gem and open the door
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !destroyed)
        {
            destroyed = true;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            go.SetActive(true);
            Destroy(this.gameObject);
            ScoreManager.instance.ChangeGemScore();
        }
    }
}
