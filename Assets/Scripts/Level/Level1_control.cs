using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1_control : MonoBehaviour
{
    public GameObject pause4Continue;
    GameController m_gc;
    public GameObject enemy;
    LevelLoader m_load;

    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_load = FindObjectOfType<LevelLoader>();
    }

    void Update()
    {
        if (m_gc.GetScore() >= 100)
        {
            DestroyImmediate(GameObject.Find("Enemy(Clone)"));

            PlayerPrefs.SetInt("levelPassed", 1);
         

            pause4Continue.SetActive(true);
        }
    }

    public void runLevelLoader()
    {
        m_load.LoadNextLevel("level_02");

    }

}
