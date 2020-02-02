using System.Collections;
using System.Collections.Generic;
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
        scoreTexts[curDisplay].GetComponent<TextMesh>().text = bonus.GetText();
        scoreTexts[curDisplay].transform.position = new Vector3(-2.11f, transform.position.y, transform.position.z);
    }

    public void DisplayTotalScore(int totalScore, int curPlayer)
    {
        scoreTexts[scoreTexts.Length - 1].GetComponent<TextMesh>().text = "ROUND TOTAL: "
        + totalScore + "    \n  GAME TOTAL: " + GameStateManager.GetPlayerScore(curPlayer);
    }
}
