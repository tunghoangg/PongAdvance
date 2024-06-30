using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 10;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private GameObject hitSFX;

    private Text P1Score;
    private Text P2Score;
    private int hitCounter;
    private Rigidbody2D rb;
    private void Awake()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
    }
    void Start()
    {
       
        Text[] canvasTexts = FindObjectsOfType<Text>();
        foreach (Text text in canvasTexts)
        {
            if (text.name == "P1Score") // Đặt tên phù hợp với Text trên Canvas
            {
                P1Score = text; // Gán cho P1Score
            }
            else if (text.name == "P2Score") // Đặt tên phù hợp với Text trên Canvas
            {
                P2Score = text; // Gán cho P2Score
            }
        }
            rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindGameObjectsWithTag("Ball").Length > 1)
        {
            Invoke("StartBall", 0f);
        }
        else
        {
            Invoke("StartBall", 2f);
        }
        
    }
    private void FixedUpdate()
    {

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }
    private void StartBall()
    {
       
            rb.velocity = new Vector2(UnityEngine.Random.Range(0f, 1f) >= 0.5f ? 1f : -1f, UnityEngine.Random.Range(-1f, 1f)) * (initialSpeed + speedIncrease * hitCounter);
        
    }
    //private void ResetBall()
    //{
    //    rb.velocity = new Vector2(0, 0);
    //    transform.position = Vector2.zero;
    //    hitCounter = 0;
    //    Invoke("StartBall", 3f);

    //}
    private void Bounce (Transform myObject)
    {
        hitCounter++;
        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;
        float xDirection, yDirection;
        if( transform.position.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }
        yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        if(yDirection == 0)
        {
            yDirection = 0.25f;
        }
        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCounter));
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2" || collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            Bounce(collision.transform);
        }
        Instantiate(hitSFX);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.tag == "Goal")
        {
            if (transform.position.x > 0)
            {
                Destroy(gameObject);
                if((int.Parse(P1Score.text) + 1) == 7)
                {
                    GameOverResultHolder.GameOverResult = "P1Win";
                    SceneManager.LoadScene("Game Over");
                }
                else
                {
                    P1Score.text = (int.Parse(P1Score.text) + 1).ToString();
                }
               

            }
            if (transform.position.x < 0)
            {
                Destroy(gameObject);
                if ((int.Parse(P2Score.text) + 1) == 7)
                {
                    GameOverResultHolder.GameOverResult = "P2Win";
                    SceneManager.LoadScene("Game Over");
                }
                else
                {
                    P2Score.text = (int.Parse(P2Score.text) + 1).ToString();
                }
                

            }
        }
           
        
        
    }
  
}
