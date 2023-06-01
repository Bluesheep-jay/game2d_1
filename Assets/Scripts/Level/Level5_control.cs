using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5_control : MonoBehaviour
{
    public GameObject pause4Continue;
    public GameObject WinPanel;
    GameController m_gc;
    LevelLoader m_load;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_load = FindObjectOfType<LevelLoader>();
    }

    void Update()
    {

        if (m_gc.GetScore() >= 300)
        {
            DestroyImmediate(GameObject.Find("Enemy5(Clone)"));
            DestroyImmediate(GameObject.FindWithTag("EnemyProjectile"));
            
            PlayerPrefs.SetInt("levelPassed", 5);

            //pause4Continue.SetActive(true);
            WinPanel.SetActive(true);

        }
    }

    public void runLevelLoader()
    {
        m_load.LoadNextLevel("level_05");

    }
}
