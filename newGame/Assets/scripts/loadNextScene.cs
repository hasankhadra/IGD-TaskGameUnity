using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadNextScene : MonoBehaviour
{
    // If the player reaches the finalt door while having the gem, he moves to the next level
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ScoreManager.haveGem)
            {
                ScoreManager.haveGem = false;
                SceneSelecter.Level2();
            }
        }
    }
}
