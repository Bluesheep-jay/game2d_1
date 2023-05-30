using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_control : MonoBehaviour
{
    public GameObject pause4Continue;
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
        if (m_gc.GetScore() >= 200)
        {
            DestroyImmediate(GameObject.Find("Couple Enemy(Clone)"));
            DestroyImmediate(GameObject.Find("Enemy3_2(Clone)"));


            pause4Continue.SetActive(true);

            //m_load.LoadNextLevel("level_02");
        }
    }

    public void runLevelLoader()
    {
        m_load.LoadNextLevel("level_04");

    }

}
