using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "leftWall")
        {
            GetComponent<AudioSource>().Play();
            GameManager.GameScore(-1);
        }
            
        else if (gameObject.name == "rightWall")
        {
            GetComponent<AudioSource>().Play();
            GameManager.GameScore(1);
        }
            

        collision.gameObject.SendMessage("resetPosition");
    }

    
}
