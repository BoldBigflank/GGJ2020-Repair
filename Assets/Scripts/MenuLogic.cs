using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogic : MonoBehaviour
{
    [SerializeField] GameObject mainScreen, infoScreen, selectPlayerCount, playerSelect;
    [SerializeField] GameObject storyScreen, controlsScreen, creditsScreen; //Info screen text
    [SerializeField] CharacterSelector characterSelector;

    public void DisplayPlayerCountScreen()
    {
        selectPlayerCount.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void DisplayMainScreen()
    {
        mainScreen.SetActive(true);
        infoScreen.SetActive(false);
        selectPlayerCount.SetActive(false);
    }

    public void DisplayInfoScreen()
    {
        mainScreen.SetActive(false);
        infoScreen.SetActive(true);
        DisplayStoryScreen();
    }

    private void DisplayPlayerSelectScreen()
    {
        selectPlayerCount.SetActive(false);
        playerSelect.SetActive(true);
    }

    public void DisplayStoryScreen()
    {
        storyScreen.SetActive(true);
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void DisplayControlsScreen()
    {
        storyScreen.SetActive(false);
        controlsScreen.SetActive(true);
        creditsScreen.SetActive(false);
    }

    public void DisplayCreditsScreen()
    {
        storyScreen.SetActive(false);
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void SelectPlayerCount(int players)
    {
        GameStateManager.SetNumberOfPlayers(players);
        playerSelect.SetActive(true);
        selectPlayerCount.SetActive(false);
        DisplayPlayerSelectScreen();
        characterSelector.StartCharacterSelection();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
