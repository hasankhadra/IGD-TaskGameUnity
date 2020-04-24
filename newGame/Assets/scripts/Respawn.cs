using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Respawn the player every time he touches an enemy
// He respawns in the last coin he touched (or in the first of the game in case he didn't touch any
public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    public static Vector3 respawnPoint = new Vector3();
    public static int counter = 0;
    bool respawn = false; 
    public Animator animator;

    private void Start()
    {
        respawnPoint = Player.transform.position;
    }

    // Check if the player hit an enemy
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            respawn = true;
        }
    }

    private void Update()
    {
        // Respawn the player in the last check point
        if (respawn)
        {
            if(Player.transform.position.y < -12)
            {
                Player.GetComponent<CircleCollider2D>().isTrigger = false;
                Player.GetComponent<BoxCollider2D>().isTrigger = false;
                animator.SetBool("isDead", false);
                Player.transform.localPosition = respawnPoint;
                respawn = false;
            }
        }
    }

}
