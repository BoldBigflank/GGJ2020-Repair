using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    [SerializeField] GameObject[] winSprites;
    // Start is called before the first frame update
    void Start()
    {
        int winningPlayer = 0;
        int winningScore = -50;
        for (int i = 0; i < GameStateManager.GetNumberOfPlayers(); i++)
        {
            if (GameStateManager.GetPlayerScore(i) > winningScore)
            {
                winningScore = GameStateManager.GetPlayerScore(i);
                winningPlayer = i;
            }
        }
        winSprites[winningPlayer].GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
