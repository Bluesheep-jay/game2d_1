using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameMenuControlScript : MonoBehaviour
{
    public Button level2, level3, level4, level5, level6, level7, level8, level9, level10;
    int levelPassed;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;
    public GameObject lock5;
    public GameObject lock6;

    // Start is called before the first frame update 
    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("levelPassed");
        level2.interactable = false;
        level3.interactable = false;
        level4.interactable = false;
        level5.interactable = false;
        level6.interactable = false;
        level7.interactable = false;
        level8.interactable = false;
        level9.interactable = false;
        level10.interactable = false;

        lock2.SetActive(true);
        lock3.SetActive(true); 
        lock4.SetActive(true);
        lock5.SetActive(true);
        lock6.SetActive(true);

        switch (levelPassed)
        {
            case 1:
                level2.interactable = true;
                lock2.SetActive(false);
                break;
            case 2:
                level2.interactable = true;
                lock2.SetActive(false);
                level3.interactable = true;
                lock3.SetActive(false);
                break;
            case 3:
                level2.interactable = true;
                lock2.SetActive(false);
                level3.interactable = true;
                lock3.SetActive(false);
                level4.interactable = true;
                lock4.SetActive(false);
                break;
            case 4:
                level2.interactable = true;
                lock2.SetActive(false);
                level3.interactable = true;
                lock3.SetActive(false);
                level4.interactable = true;
                lock4.SetActive(false);
                level5.interactable = true;
                lock5.SetActive(false);
                break;
            case 5:
                level2.interactable = true;
                lock2.SetActive(false);
                level3.interactable = true;
                lock3.SetActive(false);
                level4.interactable = true;
                lock4.SetActive(false);
                level5.interactable = true;
                lock5.SetActive(false);
                level6.interactable = true;
                lock6.SetActive(false);
                break;
            case 0:
                break;

        }
    }
     
    public void resetLevel()
    {
        Debug.Log("rest");
        PlayerPrefs.SetInt("levelPassed",0);
        SceneManager.LoadScene("Level Selection");
    }
    public void levelToLoad(int level)
    {
        SceneManager.LoadScene(level);  
    }
}
