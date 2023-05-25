using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanage : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public GameObject gameOverPanel;
    public Text livesText;

    public void SetScoreText(string txt)
    {
        if(scoreText)
        {
            scoreText.text = txt;
        }
    }
    public void ShowGameOverPanel(bool isShow)
    {
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(isShow);
        }
    }
    public void ShowPlayerLives(string txt)
    {
        if (livesText)
        {
            livesText.text = txt;
        }
    }
}
