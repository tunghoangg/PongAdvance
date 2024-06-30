using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    [SerializeField] bool ballStorm;
    [SerializeField] bool powerUp;

    [SerializeField] GameObject basicBallPrefab;
    [SerializeField] GameObject x3BallPrefab;
    [SerializeField] GameObject smallerPrefab;
    [SerializeField] GameObject largerPrefab;

    IEnumerator SpawnBallRoutine()
    {
        
        if (ballStorm) {
            while (true)
            {
                // Chờ đợi 2 giây trước khi tạo ra một Basic Ball mới
                yield return new WaitForSeconds(3f);
                // Tạo một Basic Ball mới tại vị trí của SpawnBasicBall
                Instantiate(basicBallPrefab, transform.position, Quaternion.identity);

               
            }
        }
        if (powerUp)
        {
            while (true)
            {
                
                yield return new WaitForSeconds(3f);
                Instantiate(RandomPowerUp(), new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0), Quaternion.identity);


            }
        }
        
    }
    GameObject RandomPowerUp()
    {
        GameObject[] powerUps = {x3BallPrefab,smallerPrefab,largerPrefab};
        int randomIndex = Random.Range(0, powerUps.Length);
        // Lặp qua danh sách các powerUp và thực hiện các hành động cần thiết
        return powerUps[randomIndex];
    }

    void Start()
    {
        // Bắt đầu Coroutine để tạo ra các Basic Ball
        StartCoroutine(SpawnBallRoutine());
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Ball") == null)
        {
            Instantiate(basicBallPrefab);
        }
    }

}
