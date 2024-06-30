using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpsEffect : MonoBehaviour
{
    [SerializeField] bool x3Ball;
    [SerializeField] bool smaller;
    [SerializeField] bool larger;
    
    GameObject player1;
    GameObject player2;
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(action(collision));
        Destroy(gameObject);
        
    }
    private IEnumerator action(Collider2D collision)
    {
 
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        if (x3Ball)
        {
            ball = GameObject.FindGameObjectWithTag("Ball");
            Instantiate(ball, new Vector3(ball.transform.position.x, ball.transform.position.y, 0), Quaternion.Euler(0f, 0f, 1f));
            Instantiate(ball, new Vector3(ball.transform.position.x, ball.transform.position.y, 0), Quaternion.Euler(0f, 0f, -1f));
        }
        else if (larger)
        {
            if ( collision.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                
                player1.transform.localScale = new Vector3(player1.transform.localScale.x, 2.1f, player1.transform.localScale.z);
                yield return new WaitForSeconds(1f);
                Debug.Log("Sau 1 giây");
                player1.transform.localScale = new Vector3(player1.transform.localScale.x, 1.4f, player1.transform.localScale.z);
            }
            else if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
               
                player2.transform.localScale = new Vector3(player2.transform.localScale.x, 2.1f, player2.transform.localScale.z);
                yield return new WaitForSeconds(1f);
                Debug.Log("Sau 1 giây");
                player2.transform.localScale = new Vector3(player2.transform.localScale.x, 1.4f, player2.transform.localScale.z);
            }
        }
        else if (smaller)
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {

                player1.transform.localScale = new Vector3(player1.transform.localScale.x, 0.8f, player1.transform.localScale.z);
                yield return new WaitForSeconds(1f);
                Debug.Log("Sau 1 giây");
                player1.transform.localScale = new Vector3(player1.transform.localScale.x, 1.4f, player1.transform.localScale.z);
            }
            else if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
            {

                player2.transform.localScale = new Vector3(player2.transform.localScale.x, 0.8f, player2.transform.localScale.z);
                yield return new WaitForSeconds(1f);
                Debug.Log("Sau 1 giây");
                player2.transform.localScale = new Vector3(player2.transform.localScale.x, 1.4f, player2.transform.localScale.z);
            }
        }
    }
}
