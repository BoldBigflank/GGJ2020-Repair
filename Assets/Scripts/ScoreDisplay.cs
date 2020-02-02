using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] GameObject[] scoreTexts;
    private int curDisplay;
    // Start is called before the first frame update
    void Start()
    {
        curDisplay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayNextScore(Bonus bonus)
    {
        scoreTexts[curDisplay].GetComponent<Text>().enabled = true;
        scoreTexts[curDisplay].GetComponent<Text>().text = bonus.GetText();
        curDisplay++;
    }

    public void DisplayTotalScore(int totalScore, int curPlayer)
    {
        scoreTexts[scoreTexts.Length - 1].GetComponent<Text>().enabled = true;
        scoreTexts[scoreTexts.Length - 1].GetComponent<Text>().text = "ROUND TOTAL: "
        + totalScore + "\nGAME TOTAL: " + GameStateManager.GetPlayerScore(curPlayer);
    }

    public void ResetScoreDisplay()
    {
        curDisplay = 0;
        foreach (GameObject go in scoreTexts)
        {
            go.GetComponent<Text>().enabled = false;
        }
    }
}
