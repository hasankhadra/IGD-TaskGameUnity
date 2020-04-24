using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagleThrow : MonoBehaviour
{
    public Transform respawn;
    float elapsedTime = 0f;
    public float maxTime = 1f;
    Rigidbody2D rb2d;
    public float throwPower = 50;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // Throw the eagle each (maxTime + 1) second and respawn him in the same place
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= maxTime)
        {
            transform.localPosition = respawn.localPosition;
        }
        if(elapsedTime >= maxTime + 1)
        {
            Vector2 move = new Vector2(-throwPower, 0);
            rb2d.AddForce(move);
            elapsedTime = 0;
        }
    }
}
