using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject selectplayerCount;
    public void ChangeSceneToGameLevel()
    {
        selectplayerCount.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void Select1Player()
    {
        GameStateManager.SetNumberOfPlayers(1);
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }

    public void Select2Player()
    {
        GameStateManager.SetNumberOfPlayers(2);
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }

    public void Select3Player()
    {
        GameStateManager.SetNumberOfPlayers(3);
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }

    public void Select4Player()
    {
        GameStateManager.SetNumberOfPlayers(4);
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
