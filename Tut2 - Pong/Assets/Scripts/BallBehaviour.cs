using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float force_x = 80f;
    public float force_y = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaunchBall());
        //yield return new WaitForSeconds(1f);
        //LaunchBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().AddForce(new Vector2((GetComponent<Rigidbody2D>().velocity.y / 2) + (collision.collider.GetComponent<Rigidbody2D>().velocity.y / 3), 0));
        }
    }

    IEnumerator LaunchBall()
    {
        yield return new WaitForSeconds(1f);

        if (Random.Range(0, 2) < 0.5)
        {
            //move left
            Debug.Log("left");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-force_x, -force_y));
        }
        else
        {
            //move right
            Debug.Log("right");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(force_x, force_y));
        }
    }

    public void resetPosition()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = new Vector3(0, 0);
        StartCoroutine(LaunchBall());
    }
}
