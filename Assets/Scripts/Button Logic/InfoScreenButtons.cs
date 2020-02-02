using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScreenButtons : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject infoScreen;

    public void DisplayeMainScreen()
    {
        mainScreen.SetActive(true);
        infoScreen.SetActive(false);
    }

    public void DisplayeInfoScreen()
    {
        mainScreen.SetActive(false);
        infoScreen.SetActive(true);
    }
}
