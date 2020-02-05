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
        for (int i = 0; i < 4; i++)
        {
            if (i < GameStateManager.GetNumberOfPlayers() && GameStateManager.GetPlayerScore(i) > winningScore)
            {
                winningScore = GameStateManager.GetPlayerScore(i);
                winningPlayer = i;
            }
            winSprites[i].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
