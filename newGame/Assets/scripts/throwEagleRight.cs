using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Throws the eagle, but to the right 
public class throwEagleRight : MonoBehaviour
{
    private Vector3 respawn;
    float elapsedTime = 0f;
    public float maxTime = 3f;
    Rigidbody2D rb2d;
    public float throwPower = 500;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        respawn = transform.localPosition;
    }

    // Update is called once per frame
    // Throws the eagle each (maxTime + 1) second, and respawn him in the same place
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= maxTime)
        {
            transform.localPosition = respawn;
        }
        if (elapsedTime >= maxTime + 1)
        {
            Vector2 move = new Vector2(throwPower, 0);
            rb2d.AddForce(move);
            elapsedTime = 0;
        }
    }
}
