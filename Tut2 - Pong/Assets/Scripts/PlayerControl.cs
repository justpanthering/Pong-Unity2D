using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocity = 5f;
    public KeyCode up;
    public KeyCode down;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
        {
            rb.velocity = new Vector2(0, velocity);
        }

        else if (Input.GetKey(down))
        {
            rb.velocity = new Vector2(0, -velocity);
        }

        else
            rb.velocity = new Vector2(0, 0);
    }
}
