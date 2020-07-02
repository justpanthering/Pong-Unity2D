using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Transform ball;
    public Camera mainCam;
    public GUISkin skin;
    static int Player1_Score;
    static int Player2_Score;

    public GameObject[] Walls;

    private void Start()
    {
        SpawnWalls();
        SpawnPlayers();
        Player1_Score = 0;
        Player2_Score = 0;
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    void SpawnPlayers()
    {
        Vector3 p1 = mainCam.ViewportToWorldPoint(new Vector3(0.125f, 0.5f, 0));
        player1.transform.position = new Vector3 (p1.x, p1.y, 0);

        Vector3 p2 = mainCam.ViewportToWorldPoint(new Vector3(0.875f, 0.5f, 0));
        player2.transform.position = new Vector3(p2.x, p2.y, 0);

    }

    void SpawnWalls()
    {
        //Walls = new GameObject[4];
        
        for (int i = 0; i < 4; i++)
        {
            //Walls[i] = new GameObject();

            Walls[i].AddComponent<BoxCollider2D>();
        }
        
        //top wall
        Walls[0].transform.localScale = new Vector2(mainCam.ViewportToWorldPoint (new Vector3(1f * 2, 0f, 0f)).x, 1f);
        Walls[0].transform.position = new Vector2(mainCam.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f)).x, mainCam.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f)).y);
        Debug.Log("Top Wall Created");
        //bottom wall
        Walls[1].transform.localScale = new Vector2(mainCam.ViewportToWorldPoint(new Vector3(1f * 2, 0f, 0f)).x, 1f);
        Walls[1].transform.position = new Vector2(mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f)).x, mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f)).y);
        Debug.Log("Bottom Wall Created");
        //left wall
        Walls[2].transform.localScale = new Vector2(1f, mainCam.ViewportToWorldPoint(new Vector3(0f, 1f * 2, 0f)).y);
        Walls[2].transform.position = new Vector2(mainCam.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)).x, mainCam.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f)).y);
        Walls[2].GetComponent<BoxCollider2D>().isTrigger = true;
        Walls[2].name = "leftWall";

        //right wall
        Walls[3].transform.localScale = new Vector2(1f, mainCam.ViewportToWorldPoint(new Vector3(0f, 1f * 2, 0f)).y);
        Walls[3].transform.position = new Vector2(mainCam.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)).x, mainCam.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f)).y);
        Walls[3].GetComponent<BoxCollider2D>().isTrigger = true;
        Walls[3].name = "rightWall";
    }

    public static void GameScore(int player)
    {
        if (player == -1)
            Player2_Score++;
        else
            Player1_Score++;
        Debug.Log(Player1_Score + ", " + Player2_Score);
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(Screen.width/2 - 150, 20, 100, 100), Player1_Score.ToString());
        GUI.Label(new Rect(Screen.width/2 + 150, 20, 100, 100), Player2_Score.ToString());

        if (GUI.Button(new Rect(Screen.width/2 - 121/2, 35, 121, 53), "RESET"))
        {
            Player1_Score = 0;
            Player2_Score = 0;
            ball.SendMessage("resetPosition");
        }
    }
}
