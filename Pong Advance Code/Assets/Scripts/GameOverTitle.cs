using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTitle : MonoBehaviour
{


    private void Start()
    {
        if (GameOverResultHolder.GameOverResult == "P1Win")
        {
            
           
            GetComponentInChildren<TextMeshProUGUI>().text = "Player 1 Win";
            
        }
        else if (GameOverResultHolder.GameOverResult == "P2Win")
        {
          
            GetComponentInChildren<TextMeshProUGUI>().text = "Player 2 Win";
            
        }
      
    }
}


public static class GameOverResultHolder
{
    public static string GameOverResult;
}
