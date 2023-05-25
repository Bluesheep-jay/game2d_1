using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{    
    private bool isPaused;
    public GameObject pausedPanel;
    // Start is called before the first frame update 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {     
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausedPanel.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausedPanel.SetActive(false);
        isPaused = false;   
    }
    public bool GetIsPaused()
    {
        return isPaused;
    }
}
