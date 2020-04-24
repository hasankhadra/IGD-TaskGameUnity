using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move the melee enemy from point to a point with a constant speed
public class moveEnemy : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2d;
    bool moveRight = true;
    public float minX = -15, maxX = -3; // The coordinates of the two points
    public float runSpeed = 40;
    private Vector3 Velocity = Vector3.zero;
    float horizontalMove;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = runSpeed;
        if (!moveRight)
            horizontalMove *= -1;
        animator.SetFloat("xSpeed", Mathf.Abs(horizontalMove));
        if (moveRight && transform.localPosition.x >= maxX)
        {
            flip();
        }
        if(!moveRight && transform.localPosition.x <= minX)
        {
            flip();
        }
    }
    
    private void flip()
    {
        // Switch the way the player is labelled as facing.
        moveRight = !moveRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f, 0);
        // And then smoothing it out and applying it to the character
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref Velocity, 0.05f);

    }
}
