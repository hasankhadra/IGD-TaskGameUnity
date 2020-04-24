using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    
    // If the player touches the final door in level2 he returns to the main menu
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ScoreManager.haveGem)
            {
                ScoreManager.haveGem = false;
                SceneSelecter.Menu();
            }
        }
    }
}
