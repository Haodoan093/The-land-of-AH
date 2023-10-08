using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] pageButtons;
    int unlockedLevel = 1;
    int currentPage = 0;
    int levelsPerPage = 6; 

    private void Awake()
    {
      
        ButtonsToArray();
        if (PlayerPrefs.GetInt(AnimationStrings.UnlockedLevel) > unlockedLevel)
        {
            unlockedLevel = PlayerPrefs.GetInt(AnimationStrings.UnlockedLevel);
            
        }
        UpdateButtons();
    }

    public void OpenLevel(int levelID)
    {
        string levelName = "Level" + levelID;
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(levelName);
    }

    public void NextPage()
    {
        currentPage++;
        UpdateButtons();
    }

    public void PreviousPage()
    {
        currentPage--;
        UpdateButtons();
    }

    void ButtonsToArray()
    {
        int childCount = pageButtons.Length * levelsPerPage;
        buttons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = pageButtons[i / levelsPerPage].transform.GetChild(i % levelsPerPage).gameObject.GetComponent<Button>();
        }
    }

    void UpdateButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        int startIndex = currentPage * levelsPerPage;
        int endIndex = Mathf.Min(startIndex + levelsPerPage, unlockedLevel);

        for (int i = startIndex; i < endIndex; i++)
        {
            buttons[i - (currentPage * levelsPerPage)].interactable = true;
        }
    }
   

}
