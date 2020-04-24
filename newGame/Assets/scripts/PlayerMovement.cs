using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private BoxCollider2D bc;
    private CircleCollider2D cc;
    private Rigidbody2D rb2d;
    public float runSpeed = 40f;
    float horizontalMove;
    bool jump = false;
    bool crouch = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        cc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButton("Crouch"))
        {
            crouch = true;
        }
        else
        {
            crouch = false; 
        }


        if (Input.touchCount > 0)
        {
                Touch touch = Input.GetTouch(0);

                float direction = touch.position.x > Screen.width / 2 ? 1 : -1;
                horizontalMove = direction * runSpeed;
                animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if ((Input.touchCount > 1))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
            if ((touch.position.y < Screen.width / 8))
            {
                crouch = true;
            }
        }

    }

    // Check if the player collected a coin
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }

    }

    // Check if the player hits an enemy
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("isDead", true);
            rb2d.AddForce(new Vector2(0, 350));
            bc.isTrigger = true;
            cc.isTrigger = true;
            
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);

    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
