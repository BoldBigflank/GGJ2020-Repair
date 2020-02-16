using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSelector : MonoBehaviour
{

    [SerializeField] Text selectCharacterText;
    [SerializeField] GameObject[] playerButtons;
    [SerializeField] EventSystem eventSystem;
    private CharacterColors[] characterColorsChosen;
    private int currentSelection;

    public enum CharacterColors
    {
        pink,   //0
        blue,   //1
        green,  //2
        yellow  //3
    }

    public void StartCharacterSelection()
    {
        characterColorsChosen = new CharacterColors[GameStateManager.GetNumberOfPlayers()];
        currentSelection = 0;
    }

    public void SelectCharacter(int characterColor)
    {
        characterColorsChosen[currentSelection] = (CharacterColors)characterColor;
        currentSelection++;
        SelectNextFreeCharacter();
        if (currentSelection < GameStateManager.GetNumberOfPlayers())
        {
            selectCharacterText.text = "Player " + (currentSelection + 1) + " Select Character";
        } else
        {
            GameStateManager.SetCharacterColorsChosen(characterColorsChosen);
            SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
        }
    }

    private void SelectNextFreeCharacter()
    {
        foreach (GameObject buttonObject in playerButtons)
        {
            if (buttonObject.GetComponent<Button>().interactable)
            {
                eventSystem.SetSelectedGameObject(buttonObject);
                break;
            }
        }
    }
}
